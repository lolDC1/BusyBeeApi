using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class DataTemplateEntityConfiguration : IEntityTypeConfiguration<DataTemplate>
{
    public static Guid OrderAddressSimple = new("CD081F14-3B0D-4D49-9AEA-D3CB1FE379D8");
    public static Guid OrderAddressFromWhere = new("7CFC38E6-97FC-41D6-A267-0E160C2D2FBA");

    public void Configure(EntityTypeBuilder<DataTemplate> builder)
    {
        builder
            .HasData(
                new DataTemplate
                {
                    Id = OrderAddressSimple
                },
                new DataTemplate
                {
                    Id = OrderAddressFromWhere
                }
            );
    }
}