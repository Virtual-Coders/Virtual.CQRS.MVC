
using Microsoft.EntityFrameworkCore;

namespace Virtual.CQRS.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
}
