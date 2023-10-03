﻿namespace BusyBee.Core.Interfaces.QueryParams;

public interface IQueryParams : IPagedQueryParams, ISortedQueryParams, ISearchFilterQueryParams, ITypeaheadFilterQueryParams
{
    public Guid? UserId { get; set; }
}

public interface IQueryParams<TPrimaryKey> : IQueryParams, IIdsFilterQueryParams<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
}

public interface IQueryParams<TPrimaryKey, TFilter> : IQueryParams<TPrimaryKey>, IFilterQueryParams<TFilter>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
}