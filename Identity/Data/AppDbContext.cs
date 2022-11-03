using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;

namespace Identity.Data;

public class AppDbContext : DbContext 
{
    public DbSet<User> Users { get; set; }  
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
