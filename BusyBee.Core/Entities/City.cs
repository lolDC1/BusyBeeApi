using BusyBee.Core.Common;

namespace BusyBee.Core.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = null!;

    public List<Task> Tasks { get; set; } = null!;
}