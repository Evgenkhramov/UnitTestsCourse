using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Data;


public class MinimalAPIDbContext : DbContext
{
    public MinimalAPIDbContext(DbContextOptions<MinimalAPIDbContext> options) : base(options) { }

    public virtual DbSet<Greeting> Greetings { get; set; }
}
