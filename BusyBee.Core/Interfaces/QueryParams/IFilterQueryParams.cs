namespace BusyBee.Core.Interfaces.QueryParams;

public interface IFilterQueryParams<TFilter>
{
    public TFilter? Filters { get; set; }
}