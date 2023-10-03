using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace BusyBee.Api.Authorization;

public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        RolesAuthorizationRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated == false)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var validRole = false;
        if (!requirement.AllowedRoles.Any())
        {
            validRole = true;
        }
        else
        {
            var allowedRoles = requirement.AllowedRoles;

            var claims = context.User.Claims;
            var roles = claims.FirstOrDefault(c => c.Type == "extension_Roles")?.Value.Split(',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            validRole = roles is not null && allowedRoles.Intersect(roles).Any();
        }

        if (validRole)
            context.Succeed(requirement);
        else
            context.Fail();
        return Task.CompletedTask;
    }
}