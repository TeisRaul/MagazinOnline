using Magazin_Online.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazin_Online.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdusComanda>().HasKey(pc => new
            {
                pc.ProdusId,
                pc.ComandaId
            });

            modelBuilder.Entity<ProdusComanda>().HasOne(p => p.Produs).WithMany(pc => pc.ProdusComanda).HasForeignKey(p => p.ProdusId);
            modelBuilder.Entity<ProdusComanda>().HasOne(c => c.Comanda).WithMany(pc => pc.ProdusComanda).HasForeignKey(c => c.ComandaId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produs> Produse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Admin> Admini { get; set; }
        public DbSet<ProdusComanda> ProdusComanda { get; set; }


    }
}
