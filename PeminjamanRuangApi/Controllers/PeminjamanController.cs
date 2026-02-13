using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeminjamanRuangApi.Data;
using PeminjamanRuangApi.Models;

namespace PeminjamanRuangApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeminjamanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> Get()
        {
            return await _context.Peminjamans.ToListAsync();
        }

        // PERBAIKAN DI SINI: Pastikan penulisan [FromBody] Peminjaman data benar
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Peminjaman data)
        {
            _context.Peminjamans.Add(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }

        // PERBAIKAN DI SINI: Samakan dengan struktur [FromBody] di atas
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Peminjaman dataUpdate)
        {
            var dataLama = await _context.Peminjamans.FindAsync(id);
            if (dataLama == null) return NotFound();

            dataLama.NamaPeminjam = dataUpdate.NamaPeminjam;
            dataLama.NamaRuangan = dataUpdate.NamaRuangan;
            dataLama.Tanggal = dataUpdate.Tanggal;
            dataLama.Status = dataUpdate.Status;

            await _context.SaveChangesAsync();
            return Ok("Berhasil Update");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Peminjamans.FindAsync(id);
            if (data == null) return NotFound();

            _context.Peminjamans.Remove(data);
            await _context.SaveChangesAsync();
            return Ok("Berhasil Hapus");
        }
    }
}