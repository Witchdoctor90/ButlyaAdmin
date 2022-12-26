using ButlyaFestAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace ButlyaAdmin.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Distributing> Distributings { get; set; }
    public ApplicationContext()
    {
    }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data.db");
    }
}