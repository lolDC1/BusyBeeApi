using BusyBee.Core.Entities;
using BusyBee.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Task = BusyBee.Core.Entities.Task;

namespace BusyBee.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<UserPortfolioFile> UserPortfolioFiles { get; set; } = null!;
    public DbSet<TaskDataTemplateItemValue> TaskDataTemplateItemValues { get; set; } = null!;
    public DbSet<TaskDataValue> TaskDataValues { get; set; } = null!;
    public DbSet<CategoryOfCategories> CategoriesOfCategories { get; set; } = null!;
    public DbSet<CategoryOfTasks> CategoriesOfTasks { get; set; } = null!;
    public DbSet<DataTemplate> DataTemplates { get; set; } = null!;
    public DbSet<DataTemplateItem> DataTemplateItems { get; set; } = null!;
    public DbSet<DataTemplateItemValue> DataTemplateItemValues { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        modelBuilder.IgnoreCompositePrimaryKeys();
        modelBuilder.SetDefaultDateTimeKind(DateTimeKind.Utc);
        modelBuilder.DefaultValueForAutoAuditDates();

        modelBuilder.SeedData();
    }
}