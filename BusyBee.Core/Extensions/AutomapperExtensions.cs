using AutoMapper;
using AutoMapper.Internal;

namespace BusyBee.Core.Extensions;

public static class AutomapperExtensions
{
    public static bool IsMappingExists<TSource, TDestination>(this IMapper mapper)
    {
        var rule = mapper.ConfigurationProvider.Internal().FindTypeMapFor<TSource, TDestination>();

        return rule != null;
    }

    public static TDestination MapSelfIgnored<TDestination>(this IMapper mapper, object source)
    {
        if (source is TDestination destination)
            return destination;

        return mapper.Map<TDestination>(source);
    }
}