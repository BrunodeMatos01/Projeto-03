using C_Projeto3.Model;
using Microsoft.EntityFrameworkCore;
using projeto3.api.Models;

namespace C_Projeto3.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

<<<<<<< HEAD
        public DbSet<Sale> Sales { get; set; }   
        public DbSet<User> Users { get; set; }   
=======
        public DbSet<Sale> sales { get; set; }
        public DbSet<Produto> Produtos { get; set; }

>>>>>>> b86c727dac0dfa9f2259a4c33ad3467b70a2cb4c
    }
}
