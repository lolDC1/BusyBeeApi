using BusyBee.Core.Entities;
using BusyBee.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class DataTemplateItemEntityConfiguration : IEntityTypeConfiguration<DataTemplateItem>
{
    private readonly Guid _guid1 = new("90883A11-4A54-4C3E-B574-4B1D033C391D");
    private readonly Guid _guid2 = new("0D6701CA-8E30-4105-A9F8-6485B02EAFFA");
    private readonly Guid _guid3 = new("1F7DCAB2-0C35-47C5-B433-F2334C1EDE08");

    public void Configure(EntityTypeBuilder<DataTemplateItem> builder)
    {
        builder
            .HasOne(e => e.DataTemplate)
            .WithMany(e => e.DataTemplateItems)
            .HasForeignKey(e => e.DataTemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasData(new DataTemplateItem
            {
                Id = _guid1,
                Title = "Адрес",
                Type = DataTemplateType.String,
                DataTemplateId = DataTemplateEntityConfiguration.OrderAddressSimple
            }, new DataTemplateItem
            {
                Id = _guid2,
                Title = "От",
                Type = DataTemplateType.String,
                DataTemplateId = DataTemplateEntityConfiguration.OrderAddressFromWhere
            }, new DataTemplateItem
            {
                Id = _guid3,
                Title = "До",
                Type = DataTemplateType.String,
                DataTemplateId = DataTemplateEntityConfiguration.OrderAddressFromWhere
            });
    }
}