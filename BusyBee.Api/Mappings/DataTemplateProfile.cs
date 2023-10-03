using AutoMapper;
using BusyBee.Core.Entities;
using BusyBee.Core.Models.DataTemplate;
using BusyBee.Core.Models.DataTemplate.DataTemplateItem;
using BusyBee.Core.Models.DataTemplate.DataTemplateItem.DataTemplateItemValue;

namespace BusyBee.Api.Mappings;

public class DataTemplateProfile : Profile
{
    public DataTemplateProfile()
    {
        CreateMap<DataTemplateCreateCommand, DataTemplate>();
        CreateMap<DataTemplateItemCreateCommand, DataTemplateItem>()
            .ForMember(x => x.DataTemplateAdditional, opt => opt.MapFrom(x => x.Selection)); // TODO: send null, if array is empty
        CreateMap<DataTemplateItemValueCreateCommand, DataTemplateItemValue>();

        CreateMap<DataTemplate, DataTemplateResponse>();
        CreateMap<DataTemplateItem, DataTemplateItemResponse>()
            .ForMember(x => x.Selection, opt => opt.MapFrom(src => src.DataTemplateAdditional));
        CreateMap<DataTemplateItemValue, DataTemplateItemValueResponse>();
    }
}