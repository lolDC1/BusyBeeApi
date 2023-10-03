using BusyBee.Core.Common;
using BusyBee.Core.Configurations;
using BusyBee.Core.Entities.Base;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.QueryParams;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Interfaces.Services;
using BusyBee.Core.Interfaces.Services.Domain.Common;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BusyBee.Core.Services.Domain.Common;

public class CategoryCommonServiceBase<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse,
    TAutocomplete, TQueryParams> :
    EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete, TQueryParams>,
    ICategoryCommonService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete, TQueryParams>
    where TEntity : CategoryBase, IEntity<TPrimaryKey>
    where TCreateCommand : class
    where TUpdateCommand : class
    where TListResponse : class, IIconFilename
    where TDetailedResponse : class, IIconFilename
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TQueryParams : IQueryParams<TPrimaryKey>
{
    private readonly IOptions<LocalStorageOptions> _localStorageOptions;
    private readonly ILocalStorageService _localStorageService;

    public CategoryCommonServiceBase(
        IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, TQueryParams> repository,
        EntityCrudServiceCommonDependencies dependencies,
        ILocalStorageService localStorageService,
        IOptions<LocalStorageOptions> localStorageOptions,
        IValidator<TCreateCommand>? createValidator = default,
        IValidator<UpdateValidationModel<TPrimaryKey, TUpdateCommand>>? updateValidator = default)
        : base(repository, dependencies, createValidator, updateValidator)
    {
        _localStorageService = localStorageService;
        _localStorageOptions = localStorageOptions;
    }

    public override async Task<PagedResult<TListResponse>> GetAsync(TQueryParams? queryParams = default, CancellationToken token = default)
    {
        var models = await base.GetAsync(queryParams, token);
        foreach (var model in models.Results.Where(model => model.IconFilename is not null))
            model.IconFilename = AddPrefixToFilename(model.IconFilename!);

        return models;
    }


    public override async Task<TDetailedResponse?> GetByIdAsync(TPrimaryKey id, bool isRequired,
        AccessRightsPolicyParams? accessRightsPolicyParams = default,
        CancellationToken token = default)
    {
        var model = await base.GetByIdAsync(id, isRequired, accessRightsPolicyParams, token);
        if (model?.IconFilename is not null) model.IconFilename = AddPrefixToFilename(model.IconFilename);
        return model;
    }

    public async Task<ValueAccessor<TPrimaryKey>> CreateAsync(TCreateCommand createCommand, Stream? iconFileStream,
        string? iconFileExtension,
        CancellationToken token = default)
    {
        var filename = iconFileStream is not null && iconFileExtension is not null ? GetFilename(iconFileExtension) : null;

        await ThrowIfCommandNotValid(createCommand, CreateValidator, token);
        var entityToCreate = Mapper.MapSelfIgnored<TEntity>(createCommand);
        entityToCreate.IconFilename = filename;
        var created = await Repository.CreateAsync(entityToCreate, token);

        if (filename is not null)
            await _localStorageService.UploadFileAsync(filename, _localStorageOptions.Value.ImagesFolderPath, iconFileStream!, token);

        return created.ValueAccessor;
    }

    public async Task UpdateAsync(TPrimaryKey id, TUpdateCommand updateCommand, Stream? fileStream, string? fileExtension,
        CancellationToken token = default)
    {
        await ThrowIfCommandNotValid(new UpdateValidationModel<TPrimaryKey, TUpdateCommand>(id, updateCommand), UpdateValidator, token);
        var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);

        Mapper.Map(updateCommand, entity);
        var oldIconFilename = entity!.IconFilename;
        entity.IconFilename = fileStream is not null && fileExtension is not null ? GetFilename(fileExtension) : null;
        await Repository.UpdateAsync(entity, token);

        if (oldIconFilename is not null)
            await _localStorageService.DeleteFileAsync(oldIconFilename, _localStorageOptions.Value.ImagesFolderPath, token);
        if (entity.IconFilename is not null)
            await _localStorageService.UploadFileAsync(entity.IconFilename, _localStorageOptions.Value.ImagesFolderPath, fileStream!,
                token);
    }

    public override async Task DeleteByIdAsync(TPrimaryKey id, CancellationToken token = default)
    {
        var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<AccessRightsPolicyParams>.BareView.SetRequired(), token);
        EnsureFound(id, entity);
        await Repository.DeleteAsync(entity!, token);
        if (entity!.IconFilename is not null)
            await _localStorageService.DeleteFileAsync(entity.IconFilename, _localStorageOptions.Value.ImagesFolderPath, token);
    }

    private string GetFilename(string fileExtension)
    {
        return $"{_localStorageOptions.Value.CategoryIconFilenamePrefix}{Guid.NewGuid()}{fileExtension}";
    }

    private string AddPrefixToFilename(string iconFilename)
    {
        return $"{_localStorageOptions.Value.ImagesUrlPrefix}{iconFilename}";
    }
}