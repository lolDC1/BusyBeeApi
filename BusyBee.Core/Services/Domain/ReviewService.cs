using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;

namespace BusyBee.Core.Services.Domain;

public class ReviewService : EntityCrudService<Review, Guid, ReviewCommand, ReviewCommand,
    ReviewResponse, ReviewResponse, ListItem<Guid>, ReviewQueryParams>, IReviewService
{
    public ReviewService(
        IReviewRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<ReviewCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, ReviewCommand>>? updateValidator = default)
        : base(repository, dependencies, createValidator, updateValidator)
    {
    }
}