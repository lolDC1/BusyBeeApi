using FluentValidation;

namespace BusyBee.Core.Validators.Base;

public abstract class
    AbstractUpdateValidatorForUnifiedCommand<TPrimaryKey, TCommand> : AbstractValidator<UpdateValidationModel<TPrimaryKey, TCommand>>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCommand : class
{
    protected AbstractUpdateValidatorForUnifiedCommand(IValidator<TCommand> validator)
    {
        RuleFor(x => x.Command)
            .SetValidator(validator);
    }
}