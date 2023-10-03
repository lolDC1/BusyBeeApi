﻿using System.Net;

namespace BusyBee.Core.Interfaces.Exceptions;

/// <summary>
///     Error object or exception with this interface is capable to identify HTTP status code.
/// </summary>
public interface IHttpStatusCodeSource
{
    /// <summary>Gets HTTP Status Code.</summary>
    public HttpStatusCode StatusCode { get; }
}