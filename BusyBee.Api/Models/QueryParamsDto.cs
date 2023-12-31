﻿using System.Text.Json.Serialization;
using BusyBee.Core.Interfaces.QueryParams;
using BusyBee.Core.Models.Common;

namespace BusyBee.Api.Models;

public class QueryParamsDto<TPrimaryKey> : IQueryParams<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    private int _pageNumber = IPagedQueryParams.DefaultPageNumber;
    private int _pageSize = IPagedQueryParams.DefaultPageSize;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1
            ? IPagedQueryParams.DefaultPageNumber
            : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1
            ? IPagedQueryParams.DefaultPageSize
            : value;
    }

    public string? SortBy { get; set; }
    public SortingDirectionEnum? SortDirection { get; set; }

    public string? Search { get; set; }
    public string? Typeahead { get; set; }
    public TPrimaryKey[]? Ids { get; set; }

    public Guid? UserId { get; set; }
}

public class QueryParamsDto<TPrimaryKey, TFilter> : QueryParamsDto<TPrimaryKey>, IQueryParams<TPrimaryKey, TFilter>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    [JsonIgnore] public TFilter? Filters { get; set; }
}