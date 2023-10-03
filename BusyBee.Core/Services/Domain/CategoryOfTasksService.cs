using BusyBee.Core.Configurations;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Category;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Services.Domain.Common;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BusyBee.Core.Services.Domain;

public class CategoryOfTasksService : CategoryCommonServiceBase<CategoryOfTasks, Guid, CategoryOfTasksCreateCommand,
        CategoryOfTasksUpdateCommand,
        CategoryOfTasksResponse, CategoryOfTasksResponse, ListItem<Guid>, CategoryOfTasksQueryParams>,
    ICategoryOfTasksService
{
    public CategoryOfTasksService(
        ICategoryOfTasksRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        ILocalStorageService localStorageService,
        IOptions<LocalStorageOptions> localStorageOptions,
        IValidator<CategoryOfTasksCreateCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, CategoryOfTasksUpdateCommand>>? updateValidator = default)
        : base(repository, dependencies, localStorageService, localStorageOptions, createValidator, updateValidator)
    {
    }

    public async Task<CategoryDataTemplatesResponse?> GetDataTemplatesAsync(Guid categoryId, CancellationToken token = default)
    {
        return await Repository.GetByIdProjectedAsync<CategoryDataTemplatesResponse>(categoryId,
            RepositoryQueryOptions<AccessRightsPolicyParams>.Default, token);
    }
}