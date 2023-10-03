namespace BusyBee.Core.Common;

public abstract class BaseEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
}