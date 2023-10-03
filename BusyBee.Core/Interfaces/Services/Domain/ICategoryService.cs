using BusyBee.Core.Models.Category;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryResponse>> GetAsync(CancellationToken token = default);
    public Task<CategoryDataTemplatesResponse?> GetDataTemplatesAsync(Guid id, CancellationToken token = default);
}