using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
 
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Favorite> Favorites{ get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Article>().HasKey(t=>t.ID);
        modelBuilder.Entity<User>().HasKey(t=>t.ID);
        modelBuilder.Entity<Rate>().HasKey(t=>t.ID);
        modelBuilder.Entity<Favorite>().HasKey(t=>t.ID);
    }
}