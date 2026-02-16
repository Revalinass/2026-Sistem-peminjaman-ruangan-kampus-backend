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
        public DbSet<Ruang> Ruangs { get; set; } //tambah ini buat didatabase
    }
}
