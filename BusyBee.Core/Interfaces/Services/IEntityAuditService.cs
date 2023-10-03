using BusyBee.Core.Common.AutoAuditing;
using Microsoft.EntityFrameworkCore;

namespace BusyBee.Core.Interfaces.Services;

/// <summary>
///     Handles automatic entity auditing. Affects entities marked with interfaces:
///     <see cref="IAutoAudit" />, <see cref="IAutoAuditCreated" />, <see cref="IAutoAuditCreatedAt" />, <see cref="IAutoAuditCreatedBy" />,
///     <see cref="IAutoAuditLastModified" />, <see cref="IAutoAuditLastModifiedAt" />, <see cref="IAutoAuditLastModifiedBy" />.
/// </summary>
public interface IEntityAuditService
{
    /// <summary>
    ///     Applies rules to entities tracked in the <paramref name="context" /> parameter.
    /// </summary>
    /// <param name="context">The context with tracked entities.</param>
    /// <param name="user">A user who performs this operation.</param>
    Task ApplyAuditRules(DbContext context, IUser? user = null);
}