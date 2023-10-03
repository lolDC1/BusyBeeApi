using BusyBee.Core.Configurations;
using BusyBee.Core.Entities;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Models.User;
using BusyBee.Core.Models.User.UserPortfolioFile;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;
using Microsoft.Extensions.Options;
using Task = System.Threading.Tasks.Task;

namespace BusyBee.Core.Services.Domain;

public class UserService : EntityCrudService<User, Guid, UserCommand, UserCommand,
    UserResponse, UserResponse, ListItem<Guid>, UserQueryParams>, IUserService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly EntityCrudServiceCommonDependencies _dependencies;
    private readonly IOptions<LocalStorageOptions> _localStorageOptions;
    private readonly ILocalStorageService _localStorageService;
    private readonly IUserPortfolioFileRepository _userPortfolioFileRepository;

    public UserService(
        IUserRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        ICurrentUserService currentUserService,
        ILocalStorageService localStorageService,
        IOptions<LocalStorageOptions> localStorageOptions,
        IUserPortfolioFileRepository userPortfolioFileRepository,
        IValidator<UserCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, UserCommand>>? updateValidator = default)
        : base(repository, dependencies, createValidator, updateValidator)
    {
        _dependencies = dependencies;
        _currentUserService = currentUserService;
        _localStorageService = localStorageService;
        _localStorageOptions = localStorageOptions;
        _userPortfolioFileRepository = userPortfolioFileRepository;
    }

    public async Task<ValueAccessor<Guid>> AfterRegistration(CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        var entity = await Repository.GetByIdAsync(user.UserId, RepositoryQueryOptions<AccessRightsPolicyParams>.Default, token);

        if (entity is not null) return new ValueAccessor<Guid>(() => entity.Id);

        var rnd = new Random();
        var entityToCreate = new User
        {
            Id = user.UserId,
            Name = "Profile",
            Surname = $"№ {rnd.Next(100000000, 999999999)}",
            IsDeleted = false
        };
        var created = await Repository.CreateAsync(entityToCreate, token);
        return created.ValueAccessor;
    }

    public async Task<UserResponse?> GetMe(bool isRequired = true, CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        return await GetByIdAsync(user.UserId, isRequired, token: token);
    }

    // public async Task UpdateAsync(Guid id, UserCommand updateCommand, Stream? fileStream, string? fileExtension,
    //     CancellationToken token = default)
    // {
    //     var user = await _currentUserService.GetUserAsync(token);
    //     await ThrowIfCommandNotValid(new UpdateValidationModel<Guid, UserCommand>(id, updateCommand), UpdateValidator, token);
    //
    //     var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);
    //     if (user.UserId != entity!.Id) throw _dependencies.ExceptionFactory.EntityNotFound<User>();
    //     Mapper.Map(updateCommand, entity);
    //
    //     var oldIconFilename = entity.PhotoFilename;
    //     entity.PhotoFilename = fileStream is not null && fileExtension is not null ? GetPhotoFilename(id, fileExtension) : null;
    //     await Repository.UpdateAsync(entity!, token);
    //
    //     if (oldIconFilename is not null)
    //         await _localStorageService.DeleteFileAsync(oldIconFilename, _localStorageOptions.Value.ImagesFolderPath, token);
    //     if (entity.PhotoFilename is not null)
    //         await _localStorageService.UploadFileAsync(entity.PhotoFilename, _localStorageOptions.Value.ImagesFolderPath, fileStream!,
    //             token);
    // }

    public async Task UpdatePhotoAsync(Stream fileStream, string fileExtension, CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);

        var entity = await Repository.GetByIdAsync(user.UserId, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(),
            token);
        if (user.UserId != entity!.Id) throw _dependencies.ExceptionFactory.EntityNotFound<User>();

        var oldIconFilename = entity.PhotoFilename;
        entity.PhotoFilename = GetPhotoFilename(user.UserId, fileExtension);
        await Repository.UpdateAsync(entity, token);

        if (oldIconFilename is not null)
            await _localStorageService.DeleteFileAsync(oldIconFilename, _localStorageOptions.Value.ImagesFolderPath, token);
        if (entity.PhotoFilename is not null)
            await _localStorageService.UploadFileAsync(entity.PhotoFilename, _localStorageOptions.Value.ImagesFolderPath, fileStream!,
                token);
    }

    public override async Task<UserResponse?> GetByIdAsync(Guid id, bool isRequired,
        AccessRightsPolicyParams? accessRightsPolicyParams = default, CancellationToken token = default)
    {
        var result = await Repository.GetByIdProjectedAsync<UserResponse>(id,
            RepositoryQueryOptions<AccessRightsPolicyParams>.DetailedView
                .SetRequired(isRequired)
                .SetAccessRightsPolicyParams(accessRightsPolicyParams), token);

        if (result!.PhotoFilename is not null)
            result.PhotoFilename = $"{_localStorageOptions.Value.ImagesUrlPrefix}{result.PhotoFilename}";

        foreach (var userPortfolio in result.PortfolioFiles)
            userPortfolio.Url = $"{_localStorageOptions.Value.FilesUrlPrefix}{userPortfolio.Url}";

        return result;
    }

    public async Task<ValueAccessor<Guid>> CreatePortfolioFileAsync(UserPortfolioFileCommand createCommand,
        Stream fileStream, string originalName, CancellationToken token = default)
    {
        var entityToCreate = Mapper.MapSelfIgnored<UserPortfolioFile>(createCommand);
        entityToCreate.Filename = GetPortfolioFilename(Path.GetExtension(originalName));
        entityToCreate.OriginalName = originalName;
        var created = await _userPortfolioFileRepository.CreateAsync(entityToCreate, token);
        await _localStorageService.UploadFileAsync(entityToCreate.Filename, _localStorageOptions.Value.FilesFolderPath, fileStream, token);
        return created.ValueAccessor;
    }

    public async Task DeletePortfolioFileByIdAsync(Guid id, CancellationToken token = default)
    {
        var entity = await _userPortfolioFileRepository.GetByIdAsync(id,
            RepositoryQueryOptions<AccessRightsPolicyParams>.BareView, token);

        if (entity is null) return;

        await _userPortfolioFileRepository.DeleteAsync(entity, token);
        await _localStorageService.DeleteFileAsync(entity.Filename, _localStorageOptions.Value.FilesFolderPath, token);
    }

    private string GetPhotoFilename(Guid userId, string fileExtension)
    {
        return $"{_localStorageOptions.Value.UserPhotoFilenamePrefix}{userId}{fileExtension}";
    }

    private string GetPortfolioFilename(string fileExtension)
    {
        return $"{_localStorageOptions.Value.PortfolioFilenamePrefix}{Guid.NewGuid()}{fileExtension}";
    }
}