using C_Projeto3.Model;
using Microsoft.EntityFrameworkCore;
using projeto3.api.Models;


namespace C_Projeto3.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sale> sales { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
