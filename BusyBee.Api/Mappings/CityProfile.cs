using AutoMapper;
using BusyBee.Core.Entities;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;

namespace BusyBee.Api.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        AllowNullCollections = true;

        CreateMap<City, City>();
        CreateMap<City, ListItem<Guid>>()
            .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Name));

        CreateMap<CityCommand, City>();
        CreateMap<City, CityResponse>();
    }
}