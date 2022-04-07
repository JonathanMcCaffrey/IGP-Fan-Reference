#if NO_SQL

#else

using Microsoft.EntityFrameworkCore;
using Model.Doc;
using Model.Notes;
using Model.Website;
using Model.Development.Git;
using Model.Work.Tasks;

namespace Contexts;

public class DatabaseContext : DbContext {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
        Database.EnsureCreated();
    }

    public DbSet<AgileSprintModel> AgileSprintModels { get; set; } = default!;
    public DbSet<AgileTaskModel> AgileTaskModels { get; set; } = default!;
    public DbSet<GitChangeModel> GitChangeModels { get; set; } = default!;
    public DbSet<GitPatchModel> GitPatchModels { get; set; } = default!;
    public DbSet<WebPageModel> WebPageModels { get; set; } = default!;
    public DbSet<WebSectionModel> WebSectionModels { get; set; } = default!;
    public DbSet<DocContentModel> DocContentModels { get; set; } = default!;
    public DbSet<DocConnectionModel> DocConnectionModels { get; set; } = default!;
    public DbSet<DocSectionModel> DocSectionModels { get; set; } = default!;
    public DbSet<NoteContentModel> NoteContentModels { get; set; } = default!;
    public DbSet<NoteConnectionModel> NoteConnectionModels { get; set; } = default!;
    public DbSet<NoteSectionModel> NoteSectionModels { get; set; } = default!;
}

#endif