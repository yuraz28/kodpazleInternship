using Microsoft.EntityFrameworkCore;

public class FileContext : DbContext
{
    public FileContext(DbContextOptions<FileContext> options) : base(options) {}

    public DbSet<FileRecord> FileRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FileRecord>().HasKey(t=>t.ID);
    }
}