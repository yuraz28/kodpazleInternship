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
        // modelBuilder.Entity<Article>().ToTable(t => t.HasCheckConstraint("ValidName", "Name < 100 AND Name > 10"));
        modelBuilder.Entity<User>().HasKey(t=>t.ID);
        //modelBuilder.Entity<User>().ToTable(t => t.HasCheckConstraint("ValidLogin", "Login < 20 AND Login > 5"));
        modelBuilder.Entity<Rate>().HasKey(t=>t.ID);
        modelBuilder.Entity<Rate>().ToTable(t => t.HasCheckConstraint("ValidRating", "Rating <= 10 AND Rating >= 0"));
        modelBuilder.Entity<Favorite>().HasKey(t=>t.ID);
    }
}