using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpiritLink.Data;

public class identityDbContext : IdentityDbContext<IdentityUser>
{
    public identityDbContext(DbContextOptions<identityDbContext> options)
        : base(options)
    {
    }

    protected identityDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }
}
