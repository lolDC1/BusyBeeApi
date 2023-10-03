using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BusyBee.Persistence.Design;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    private const string DefaultConnectionString = "Host=localhost;Database=busy_bee_db;Username=postgres;Password=12345678";

    public DatabaseContext CreateDbContext(string?[] args)
    {
        var connectionString = args.Any() ? args[0] ?? DefaultConnectionString : DefaultConnectionString;

        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseNpgsql(connectionString,
            builder => { builder.MigrationsAssembly(typeof(DatabaseContextFactory).Assembly.GetName().Name); });
        optionsBuilder.EnableSensitiveDataLogging();

        return new DatabaseContext(optionsBuilder.Options);
    }
}