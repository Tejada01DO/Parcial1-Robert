using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Ingresos> Ingresos { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
}