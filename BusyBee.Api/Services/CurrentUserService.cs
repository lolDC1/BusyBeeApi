using BusyBee.Api.Models;
using BusyBee.Core.Interfaces;
using BusyBee.Core.Interfaces.Services;

namespace BusyBee.Api.Services;

/// <inheritdoc />
public class CurrentUserService : ICurrentUserService
{
    private const string UserIdClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    /// <inheritdoc />
    public Task<IUser> GetUserAsync(CancellationToken token = default)
    {
        var user = _httpContextAccessor.HttpContext!.User;

        var claims = user.Claims.ToDictionary(k => k.Type, v => v.Value);
        var userId = new Guid(claims.Where(x => x.Key == UserIdClaim).Select(x => x.Value).First());

        return Task.FromResult<IUser>(new WebUser(userId, claims));
    }
}