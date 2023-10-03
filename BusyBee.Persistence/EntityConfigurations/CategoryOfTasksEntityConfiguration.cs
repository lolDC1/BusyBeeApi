using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class CategoryOfTasksEntityConfiguration : IEntityTypeConfiguration<CategoryOfTasks>
{
    public void Configure(EntityTypeBuilder<CategoryOfTasks> builder)
    {
        builder
            .HasOne(e => e.Parent)
            .WithMany(e => e.CategoriesOfTasks)
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}