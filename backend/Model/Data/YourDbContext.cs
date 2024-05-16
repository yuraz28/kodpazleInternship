using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileRecord> FileRecords { get; set; }
        // Добавьте другие DbSet для других моделей, если они есть

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка отношений между моделями, если необходимо
        }
    }
}