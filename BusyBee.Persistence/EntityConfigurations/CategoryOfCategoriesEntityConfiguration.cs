using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class CategoryOfCategoriesEntityConfiguration : IEntityTypeConfiguration<CategoryOfCategories>
{
    public void Configure(EntityTypeBuilder<CategoryOfCategories> builder)
    {
        builder
            .HasOne(e => e.Parent)
            .WithMany(e => e.ChildCategories)
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}