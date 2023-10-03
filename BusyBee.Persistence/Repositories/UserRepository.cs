using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Models.User;
using BusyBee.Persistence.Repositories.CrudBase;

namespace BusyBee.Persistence.Repositories;

public class UserRepository :
    UnitOfWorkEntityRepositoryBase<User, Guid, DatabaseContext, ListItem<Guid>, UserQueryParams>,
    IUserRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public UserRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<User, bool>>> SearchPredicate =>
        query => x => x.Id.ToString().Contains(query);

    protected override Func<string, Expression<Func<User, bool>>> TypeaheadPredicate =>
        query => x => x.Id.ToString().StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<User, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<User, object?>>>
        {
            [nameof(User.Id)] = x => x.Id
        };

    protected override async Task<IQueryable<User>> ApplyFilteringAsync(IQueryable<User> query,
        UserQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}