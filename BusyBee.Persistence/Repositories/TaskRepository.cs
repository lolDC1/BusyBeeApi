using System.Linq.Expressions;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Persistence.Repositories.CrudBase;
using Microsoft.EntityFrameworkCore;
using Task = BusyBee.Core.Entities.Task;

namespace BusyBee.Persistence.Repositories;

public class TaskRepository :
    UnitOfWorkEntityRepositoryBase<Task, Guid, DatabaseContext, ListItem<Guid>, TaskQueryParams>,
    ITaskRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryOfCategoriesRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public TaskRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<Task, bool>>> SearchPredicate =>
        query => x => x.Title.Contains(query);

    protected override Func<string, Expression<Func<Task, bool>>> TypeaheadPredicate =>
        query => x => x.Title.StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<Task, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<Task, object?>>>
        {
            [nameof(Task.Id)] = x => x.Id,
            [nameof(Task.Title)] = x => x.Title,
            [nameof(Task.Description)] = x => x.Description,
            [nameof(Task.ConfidentialInfo)] = x => x.ConfidentialInfo
        };

    protected override async Task<IQueryable<Task>> IncludeOwnedPropertiesAsync(IQueryable<Task> query,
        CancellationToken token = default)
    {
        query = await base.IncludeOwnedPropertiesAsync(query, token);

        query = query
            .Include(x => x.TaskDataTemplateItemValues)
            .Include(x => x.TaskDataValues);

        return query;
    }


    protected override async Task<IQueryable<Task>> ApplyFilteringAsync(IQueryable<Task> query,
        TaskQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}