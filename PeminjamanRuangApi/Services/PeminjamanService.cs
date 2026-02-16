using Microsoft.EntityFrameworkCore;
using PeminjamanRuangApi.Data;
using PeminjamanRuangApi.Models;

namespace PeminjamanRuangApi.Services
{
    public class PeminjamanService : IPeminjamanService // Pakai IPeminjamanService
    {
        private readonly AppDbContext _context;

        public PeminjamanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Peminjaman>> GetAllAsync() => await _context.Peminjamans.ToListAsync();

        public async Task AddAsync(PeminjamanCreateDto dto)
        {
            var ruang = await _context.Ruangs.FindAsync(dto.RuangId);
            if (ruang == null) throw new Exception("Ruangan tidak ditemukan!");

            var dataBaru = new Peminjaman
            {
                NamaPeminjam = dto.NamaPeminjam,
                NamaRuangan = ruang.NamaRuangan, 
                Tanggal = dto.Tanggal,
                Status = "Menunggu"
            };

            _context.Peminjamans.Add(dataBaru);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Peminjaman dataUpdate)
        {
            var dataLama = await _context.Peminjamans.FindAsync(id);
            if (dataLama == null) return false;

            dataLama.NamaPeminjam = dataUpdate.NamaPeminjam;
            dataLama.NamaRuangan = dataUpdate.NamaRuangan;
            dataLama.Tanggal = dataUpdate.Tanggal;
            dataLama.Status = dataUpdate.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _context.Peminjamans.FindAsync(id);
            if (data == null) return false;

            _context.Peminjamans.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}