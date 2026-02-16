using Microsoft.EntityFrameworkCore;
using PeminjamanRuangApi.Models;

namespace PeminjamanRuangApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Peminjaman> Peminjamans { get; set; }
        public DbSet<Ruang> Ruangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ruang>().HasData(
                new Ruang { Id = 1, NamaRuangan = "Lab RPL", Kapasitas = 30, Lokasi = "Gedung D3" },
                new Ruang { Id = 2, NamaRuangan = "Lab Database", Kapasitas = 30, Lokasi = "Gedung D4" },
                new Ruang { Id = 3, NamaRuangan = "D3 Theater", Kapasitas = 100, Lokasi = "Gedung D3" },
                new Ruang { Id = 4, NamaRuangan = "Lab APD", Kapasitas = 30, Lokasi = "Gedung D4" }
            );
        }
    }
}