using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class AccountDbContext : IdentityDbContext<IdentityUser>
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) :
        base(options)
    { 
        Database.EnsureCreated();
    } 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}