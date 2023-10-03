using BusyBee.Core.Interfaces;
using BusyBee.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace BusyBee.Core.Services;

/// <inheritdoc />
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IEnumerable<IEntityAuditService> _entityAuditServices;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWork{TContext}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="entityAuditServices">Services for handling automatic entity auditing.</param>
    /// <param name="currentUserService">A service for retrieving information about user who performs operation.</param>
    public UnitOfWork(TContext context, ICurrentUserService currentUserService, IEnumerable<IEntityAuditService> entityAuditServices)
    {
        _context = context;
        _currentUserService = currentUserService;
        _entityAuditServices = entityAuditServices;
    }

    /// <inheritdoc />
    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        foreach (var entityAuditService in _entityAuditServices)
            await entityAuditService.ApplyAuditRules(_context, user);
        await _context.SaveChangesAsync(token);
        DetachAll();
    }

    /// <inheritdoc />
    public void Rollback()
    {
        DetachAll();
    }

    private void DetachAll()
    {
        _context.ChangeTracker.Clear();
    }
}