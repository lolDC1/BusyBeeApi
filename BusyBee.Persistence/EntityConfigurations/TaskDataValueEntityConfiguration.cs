using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class TaskDataValueEntityConfiguration : IEntityTypeConfiguration<TaskDataValue>
{
    public void Configure(EntityTypeBuilder<TaskDataValue> builder)
    {
        builder
            .HasKey(x => new { x.TaskId, x.DataTemplateItemId });
    }
}