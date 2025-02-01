using Microsoft.EntityFrameworkCore;

namespace MimoAssignment.Models;

public partial class MimoContext : DbContext
{
    public MimoContext()
    {
    }

    public MimoContext(DbContextOptions<MimoContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=mimo.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
