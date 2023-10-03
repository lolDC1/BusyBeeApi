using AutoMapper;
using BusyBee.Api.Models.CategoryOfTasks;
using BusyBee.Core.Entities;
using BusyBee.Core.Enums;
using BusyBee.Core.Models.Category;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Persistence.EntityConfigurations;

namespace BusyBee.Api.Mappings;

public class CategoryOfTasksProfile : Profile
{
    public CategoryOfTasksProfile()
    {
        CreateMap<CategoryOfTasksCreateCommand, CategoryOfTasks>()
            .ForMember(x => x.OrderAddressDataTemplateId, opt => opt.MapFrom(x =>
                x.OrderAddressType == OrderAddressType.Simple ? DataTemplateEntityConfiguration.OrderAddressSimple :
                x.OrderAddressType == OrderAddressType.FromWhere ? (Guid?)DataTemplateEntityConfiguration.OrderAddressFromWhere : null));
        CreateMap<CategoryOfTasksUpdateCommandDto, CategoryOfTasks>();

        CreateMap<CategoryOfTasks, CategoryOfTasksResponse>()
            .ForMember(x => x.CountOfTasks, opt => opt.MapFrom(x => x.Tasks.Count));
        CreateMap<CategoryOfTasks, CategoryDataTemplatesResponse>();

        CreateMap<CategoryOfTasksResponse, CategoryResponse>();
    }
}