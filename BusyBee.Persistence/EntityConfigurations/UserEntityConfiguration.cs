using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(r => r.PortfolioFiles)
            .WithOne(b => b.User)
            .HasForeignKey(r => r.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);
    }
}