using AutoMapper;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Category;
using BusyBee.Core.Models.CategoryOfCategories;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Core.Services.Domain.CrudBase;

namespace BusyBee.Core.Services.Domain;

public class CategoryService : ICategoryService
{
    private readonly ICategoryOfCategoriesService _categoryOfCategoriesService;
    private readonly ICategoryOfTasksService _categoryOfTasksService;
    private readonly IMapper _mapper;

    public CategoryService(EntityCrudServiceCommonDependencies dependencies, ICategoryOfTasksService categoryOfTasksService,
        ICategoryOfCategoriesService categoryOfCategoriesService)
    {
        _mapper = dependencies.Mapper;
        _categoryOfTasksService = categoryOfTasksService;
        _categoryOfCategoriesService = categoryOfCategoriesService;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAsync(CancellationToken token = default)
    {
        var categoryOfTasksQuery = new CategoryOfTasksQueryParams { PageSize = int.MaxValue };
        var categoryOfCategoriesQuery = new CategoryOfCategoriesQueryParams { PageSize = int.MaxValue };
        var categoryOfTasks = (await _categoryOfTasksService.GetAsync(categoryOfTasksQuery, token)).Results;
        var categoryOfCategories = (await _categoryOfCategoriesService.GetAsync(categoryOfCategoriesQuery, token)).Results;

        var categories = new List<CategoryResponse>();
        categories.AddRange(_mapper.Map<CategoryResponse[]>(categoryOfTasks));
        categories.AddRange(_mapper.Map<CategoryResponse[]>(categoryOfCategories));

        return GetChildren(null, categories.ToArray());
    }

    public async Task<CategoryDataTemplatesResponse?> GetDataTemplatesAsync(Guid id, CancellationToken token = default)
    {
        return await _categoryOfTasksService.GetDataTemplatesAsync(id, token);
    }

    private static CategoryResponse[] GetChildren(Guid? parentId, CategoryResponse[] allEntities)
    {
        return allEntities.Where(e => e.ParentId == parentId)
            .Select(e =>
            {
                var children = GetChildren(e.Id, allEntities);

                return new CategoryResponse
                {
                    Id = e.Id,
                    ParentId = e.ParentId,
                    Title = e.Title,
                    IconFilename = e.IconFilename,
                    CountOfTasks = children.Any() ? children.Sum(x => x.CountOfTasks) : e.CountOfTasks,
                    // PaymentDataTemplateId = e.PaymentDataTemplateId,
                    // OrderAddressDataTemplateId = e.OrderAddressDataTemplateId,

                    Children = children.Any() ? children : null
                };
            })
            .ToArray();
    }
}