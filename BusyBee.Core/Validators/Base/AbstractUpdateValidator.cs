using FluentValidation;

namespace BusyBee.Core.Validators.Base;

public abstract class AbstractUpdateValidator<TPrimaryKey, TCommand> : AbstractValidator<UpdateValidationModel<TPrimaryKey, TCommand>>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCommand : class
{
}