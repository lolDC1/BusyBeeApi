using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.User;
using BusyBee.Core.Models.User.UserPortfolioFile;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface IUserService : IEntityCrudService<
    Guid,
    UserCommand,
    UserCommand,
    UserResponse,
    UserResponse,
    ListItem<Guid>,
    UserQueryParams>
{
    public Task<UserResponse?> GetMe(bool isRequired = true, CancellationToken token = default);

    public Task UpdatePhotoAsync(Stream fileStream, string fileExtension, CancellationToken token = default);

    public Task<ValueAccessor<Guid>> AfterRegistration(CancellationToken token = default);

    public Task<ValueAccessor<Guid>> CreatePortfolioFileAsync(UserPortfolioFileCommand createCommand,
        Stream fileStream, string originalName, CancellationToken token = default);

    public Task DeletePortfolioFileByIdAsync(Guid id, CancellationToken token = default);
}