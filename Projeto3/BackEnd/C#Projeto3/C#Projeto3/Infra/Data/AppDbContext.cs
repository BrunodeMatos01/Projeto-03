using C_Projeto3.Model;
using Microsoft.EntityFrameworkCore;


namespace C_Projeto3.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sale> sales { get; set; }

    }
}
