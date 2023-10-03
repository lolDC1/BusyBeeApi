using BusyBee.Persistence.Design;
using Microsoft.EntityFrameworkCore;

var connectionString = args.Any() ? args[0] : Environment.GetEnvironmentVariable("SqlDatabase");

Console.WriteLine("Started BusyBee.Persistence.Design console add.");
using (var context = new DatabaseContextFactory().CreateDbContext(new[] { connectionString }))
{
    Console.WriteLine("Applying migrations.");
    context.Database.MigrateAsync().Wait();
    Console.WriteLine("Migrations applied.");
}

Console.WriteLine("All done, you can close the console now.");