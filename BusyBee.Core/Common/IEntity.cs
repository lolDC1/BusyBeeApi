namespace BusyBee.Core.Common;

public interface IEntity
{
    Guid Id { get; set; }
}

public interface IEntity<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}