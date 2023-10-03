using AutoMapper;
using BusyBee.Core.Entities;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.User;
using BusyBee.Core.Models.User.UserPortfolioFile;

namespace BusyBee.Api.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        AllowNullCollections = true;

        CreateMap<User, User>();
        CreateMap<User, ListItem<Guid>>()
            .ForMember(x => x.Title, opt => opt.MapFrom(x => $"{x.Name} {x.Surname}"));

        CreateMap<UserCommand, User>()
            .ForMember(x => x.Birthday,
                opt => opt.MapFrom(x => x.Birthday.HasValue ? DateOnly.FromDateTime(x.Birthday!.Value) : (DateOnly?)null));
        CreateMap<User, UserResponse>()
            .ForMember(x => x.CityName, opt => opt.MapFrom(x => x.City != null ? x.City.Name : null))
            .ForMember(x => x.OrderCategories, opt => opt.MapFrom(x => x.Tasks.Select(y => y.CategoryOfTasks.Title).Distinct()))
            .ForMember(x => x.OrderCities, opt => opt.MapFrom(x => x.Tasks.Select(y => y.City.Name).Distinct()));

        CreateMap<UserPortfolioFileCommand, UserPortfolioFile>();
        CreateMap<UserPortfolioFile, UserPortfolioFileResponse>()
            .ForMember(x => x.Url, opt => opt.MapFrom(x => x.Filename));
    }
}