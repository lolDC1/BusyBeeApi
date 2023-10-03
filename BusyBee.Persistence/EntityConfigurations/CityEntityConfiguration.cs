using BusyBee.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusyBee.Persistence.EntityConfigurations;

public class CityEntityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasData(new List<City>
        {
            new()
            {
                Id = new Guid("67CAC13E-DC65-4FD0-AE3B-DD4C2C323064"),
                Name = "Одеса"
            },
            new()
            {
                Id = new Guid("537AF92C-2C7B-4D87-9A79-2FB712C96AE2"),
                Name = "Київ"
            },
            new()
            {
                Id = new Guid("44E7002D-F472-40DD-98DC-676D3D36173D"),
                Name = "Львiв"
            },
            new()
            {
                Id = new Guid("5C54A8FA-7B30-4952-A0E1-3D133E8B150C"),
                Name = "Харкiв"
            }
        });
    }
}