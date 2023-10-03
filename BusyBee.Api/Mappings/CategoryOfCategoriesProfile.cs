using AutoMapper;
using BusyBee.Core.Entities;
using BusyBee.Core.Models.Category;
using BusyBee.Core.Models.CategoryOfCategories;

namespace BusyBee.Api.Mappings;

public class CategoryOfCategoriesProfile : Profile
{
    public CategoryOfCategoriesProfile()
    {
        CreateMap<CategoryOfCategories, CategoryOfCategoriesResponse>()
            .ForMember(x => x.CountOfTasks, opt => opt.MapFrom(_ => 0));
        CreateMap<CategoryOfCategoriesResponse, CategoryResponse>();

        CreateMap<CategoryOfCategoriesCreateCommand, CategoryOfCategories>();

        CreateMap<CategoryOfCategoriesUpdateCommand, CategoryOfCategories>();
    }
}