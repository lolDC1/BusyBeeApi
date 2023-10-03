namespace BusyBee.Core.Validators.Base;

public record UpdateValidationModel<TPrimaryKey, TCommand>(TPrimaryKey EntityId, TCommand Command)
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCommand : class;