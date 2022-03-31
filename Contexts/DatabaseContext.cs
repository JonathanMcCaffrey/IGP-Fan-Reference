#if NO_SQL

#else

using Microsoft.EntityFrameworkCore;
using Model.Website;
using Model.Work.Git;
using Model.Work.Tasks;

namespace Contexts;

public class DatabaseContext : DbContext {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
        Database.EnsureCreated();
    }

    public DbSet<SprintModel> SprintModels { get; set; }
    public DbSet<TaskModel> TaskModels { get; set; }
    public DbSet<ChangeModel> ChangeModels { get; set; }
    public DbSet<PatchModel> PatchModels { get; set; }
    public DbSet<WebPageModel> WebPageModels { get; set; }
    public DbSet<WebSectionModel> WebSectionModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<PatchModel>();
        modelBuilder.Entity<TaskModel>();

        base.OnModelCreating(modelBuilder);
    }
}

#endif