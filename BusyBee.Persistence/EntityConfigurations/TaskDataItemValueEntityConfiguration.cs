using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class TaskDataItemValueEntityConfiguration : IEntityTypeConfiguration<TaskDataTemplateItemValue>
{
    public void Configure(EntityTypeBuilder<TaskDataTemplateItemValue> builder)
    {
        builder
            .HasKey(x => new { x.TaskId, x.DataTemplateItemId, x.DataTemplateItemValueId });
    }
}