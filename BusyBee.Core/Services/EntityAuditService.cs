using BusyBee.Core.Common.AutoAuditing;
using BusyBee.Core.Interfaces;
using BusyBee.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace BusyBee.Core.Services;

/// <inheritdoc />
public class EntityAuditService : IEntityAuditService
{
    private readonly IDateTimeService _dateTimeService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityAuditService" /> class.
    /// </summary>
    /// <param name="dateTimeService">The DateTime service.</param>
    public EntityAuditService(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc />
    public Task ApplyAuditRules(DbContext context, IUser? user = null)
    {
        var now = _dateTimeService.NowUtc;

        foreach (var entry in context.ChangeTracker.Entries().Where(x => x.State is EntityState.Modified or EntityState.Added))
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity is IAutoAuditCreatedAt autoAuditCreatedAt) autoAuditCreatedAt.CreatedAt = now;

                if (entry.Entity is IAutoAuditCreatedBy autoAuditCreatedBy) autoAuditCreatedBy.CreatedBy = user?.UserId ?? Guid.Empty;
            }

            if (entry.Entity is IAutoAuditLastModifiedAt autoAuditUpdatedAt &&
                (entry.State == EntityState.Modified || entry.Entity is not IAutoAuditCreatedAt))
                autoAuditUpdatedAt.LastModifiedAt = now;

            if (entry.Entity is IAutoAuditLastModifiedBy autoAuditUpdatedBy &&
                (entry.State == EntityState.Modified || entry.Entity is not IAutoAuditCreatedBy))
                autoAuditUpdatedBy.LastModifiedBy = user?.UserId;
        }

        return Task.CompletedTask;
    }
}