using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.Common;

namespace BusyBee.Core.Interfaces.Services.Domain.Common;

public interface ICategoryCommonService<TPrimaryKey, in TCreateCommand, in TUpdateCommand, TListResponse, TDetailedResponse,
    TAutocomplete, in TQueryParams> : IEntityCrudService<
    TPrimaryKey,
    TCreateCommand,
    TUpdateCommand,
    TListResponse,
    TDetailedResponse,
    TAutocomplete,
    TQueryParams>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    public Task<ValueAccessor<TPrimaryKey>> CreateAsync(TCreateCommand createCommand, Stream? iconFileStream, string? iconFileExtension,
        CancellationToken token = default);

    public Task UpdateAsync(TPrimaryKey id, TUpdateCommand updateCommand, Stream? fileStream, string? fileExtension,
        CancellationToken token = default);
}