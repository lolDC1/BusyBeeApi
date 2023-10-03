using BusyBee.Core.Configurations;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.CategoryOfCategories;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Services.Domain.Common;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BusyBee.Core.Services.Domain;

public class CategoryOfCategoriesService : CategoryCommonServiceBase<CategoryOfCategories, Guid, CategoryOfCategoriesCreateCommand,
        CategoryOfCategoriesUpdateCommand,
        CategoryOfCategoriesResponse, CategoryOfCategoriesResponse, ListItem<Guid>, CategoryOfCategoriesQueryParams>,
    ICategoryOfCategoriesService
{
    public CategoryOfCategoriesService(
        ICategoryOfCategoriesRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        ILocalStorageService localStorageService,
        IOptions<LocalStorageOptions> localStorageOptions,
        IValidator<CategoryOfCategoriesCreateCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, CategoryOfCategoriesUpdateCommand>>? updateValidator = default)
        : base(repository, dependencies, localStorageService, localStorageOptions, createValidator, updateValidator)
    {
    }
}