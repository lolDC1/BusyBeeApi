using BusyBee.Core.Entities;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Models.Review;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;
using Task = BusyBee.Core.Entities.Task;
using TaskStatus = BusyBee.Core.Enums.TaskStatus;

namespace BusyBee.Core.Services.Domain;

public class TaskService : EntityCrudService<Task, Guid, TaskCreateCommand, TaskUpdateCommand, TaskResponse, TaskResponse, ListItem<Guid>,
    TaskQueryParams>, ITaskService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IReviewRepository _reviewRepository;
    private readonly IValidator<ReviewCommand>? _reviewValidator;

    public TaskService(
        ITaskRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        ICurrentUserService currentUserService,
        IReviewRepository reviewRepository,
        IValidator<TaskCreateCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, TaskUpdateCommand>>? updateValidator = default,
        IValidator<ReviewCommand>? reviewValidator = default)
        : base(repository, dependencies, createValidator, updateValidator)
    {
        _currentUserService = currentUserService;
        _reviewRepository = reviewRepository;
        _reviewValidator = reviewValidator;
    }

    public override async System.Threading.Tasks.Task UpdateAsync(Guid id, TaskUpdateCommand updateCommand,
        CancellationToken token = default)
    {
        await ThrowIfCommandNotValid(new UpdateValidationModel<Guid, TaskUpdateCommand>(id, updateCommand), UpdateValidator, token);
        var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);
        Mapper.Map(updateCommand, entity);
        entity!.Status = TaskStatus.Opened;
        await Repository.UpdateAsync(entity, token);
    }

    public async System.Threading.Tasks.Task CloseAsync(Guid id, CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);
        if (entity!.CreatedBy != user.UserId) throw ExceptionFactory.EntityNotFound<Task>();
        entity.Status = TaskStatus.Closed;
        entity.AssignToId = null;
        await Repository.UpdateAsync(entity, token);
    }

    public async System.Threading.Tasks.Task DoAsync(ReviewCommand reviewCommand, CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        var entity = await Repository.GetByIdAsync(reviewCommand.TaskId,
            RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);
        if (entity!.CreatedBy != user.UserId) throw ExceptionFactory.EntityNotFound<Task>();
        entity.Status = TaskStatus.Done;
        await ThrowIfCommandNotValid(reviewCommand, _reviewValidator, token);
        await Repository.UpdateAsync(entity, token);
        await _reviewRepository.CreateAsync(Mapper.MapSelfIgnored<Review>(reviewCommand), token);
    }

    public async Task<PagedResult<TaskResponse>> GetMeAsync(TaskQueryParams? queryParams = default, CancellationToken token = default)
    {
        queryParams ??= new TaskQueryParams();
        queryParams.UserId = (await _currentUserService.GetUserAsync(token)).UserId;
        return await base.GetAsync(queryParams, token);
    }

    public async System.Threading.Tasks.Task AssignAsync(Guid taskId, CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        var entity = await Repository.GetByIdAsync(taskId, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);
        if (entity!.AssignToId is not null) throw ExceptionFactory.ValidationProblem("Task has already assigned to user");
        entity.AssignToId = user.UserId;
        entity.Status = TaskStatus.Assigned;
        await Repository.UpdateAsync(entity, token);
    }

    public async System.Threading.Tasks.Task DeassignAsync(Guid taskId, CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        var entity = await Repository.GetByIdAsync(taskId, RepositoryQueryOptions<AccessRightsPolicyParams>.Default.SetRequired(), token);
        if (user.UserId != entity!.AssignToId) throw ExceptionFactory.ValidationProblem("You don't assigned to task");
        entity.AssignToId = null;
        entity.Status = TaskStatus.Opened;
        await Repository.UpdateAsync(entity, token);
    }

    public override Task<TaskResponse?> GetByIdAsync(Guid id, bool isRequired, AccessRightsPolicyParams? accessRightsPolicyParams = default,
        CancellationToken token = default)
    {
        // TODO: check user
        return base.GetByIdAsync(id, isRequired, accessRightsPolicyParams, token);
    }
}