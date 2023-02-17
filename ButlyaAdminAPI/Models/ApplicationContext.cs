using Microsoft.EntityFrameworkCore;

namespace ButlyaAdminAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Distributing> Distributings { get; set; }
        public DbSet<CashlessInvoice> CashlessInvoices { get; set; }
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}