using AutoMapper;
using BusyBee.Core.Entities;
using BusyBee.Core.Models.Review;

namespace BusyBee.Api.Mappings;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        AllowNullCollections = true;

        CreateMap<ReviewCommand, Review>();
        CreateMap<Review, ReviewResponse>();
    }
}