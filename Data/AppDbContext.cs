using Magazin_Online.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazin_Online.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produs> Produse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Admin> Admini { get; set; }
        public DbSet<ProdusComanda> ProdusComanda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Utilizator)
                .WithOne(u => u.Admin)
                .HasForeignKey(u => u.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Produs)
                .WithOne(p => p.Admin)
                .HasForeignKey(p => p.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Comanda)
                .WithOne(c => c.Admin)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilizator>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Utilizator>()
                .HasOne(u => u.Admin)
                .WithMany(a => a.Utilizator)
                .HasForeignKey(u => u.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilizator>()
                .HasMany(u => u.Produs)
                .WithOne(p => p.Utilizator)
                .HasForeignKey(p => p.UtilizatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilizator>()
                .HasMany(u => u.Comanda)
                .WithOne(c => c.Utilizator)
                .HasForeignKey(c => c.UtilizatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produs>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Produs>()
                .HasOne(p => p.Utilizator)
                .WithMany(u => u.Produs)
                .HasForeignKey(p => p.UtilizatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdusComanda>()
                .HasKey(pc => new { pc.ProdusId, pc.ComandaId });

            modelBuilder.Entity<ProdusComanda>()
                .HasOne(pc => pc.Produs)
                .WithMany(p => p.ProdusComanda)
                .HasForeignKey(pc => pc.ProdusId);

            modelBuilder.Entity<ProdusComanda>()
                .HasOne(pc => pc.Comanda)
                .WithMany(c => c.ProdusComanda)
                .HasForeignKey(pc => pc.ComandaId);

            modelBuilder.Entity<Comanda>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Utilizator)
                .WithMany(u => u.Comanda)
                .HasForeignKey(c => c.UtilizatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Admin)
                .WithMany(a => a.Comanda)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
