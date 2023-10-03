using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = BusyBee.Core.Entities.Task;

namespace BusyBee.Persistence.EntityConfigurations;

public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder
            .HasOne(r => r.CategoryOfTasks)
            .WithMany(b => b.Tasks)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.City)
            .WithMany(b => b.Tasks)
            .HasForeignKey(r => r.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.User)
            .WithMany(b => b.Tasks)
            .HasForeignKey(r => r.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.AssignTo)
            .WithMany(b => b.AssignedTasks)
            .HasForeignKey(r => r.AssignToId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Review>(r => r.Review)
            .WithOne(b => b.Task)
            .HasForeignKey<Review>(r => r.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}