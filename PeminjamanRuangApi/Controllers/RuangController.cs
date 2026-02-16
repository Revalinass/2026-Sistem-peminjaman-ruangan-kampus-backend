using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeminjamanRuangApi.Data;
using PeminjamanRuangApi.Models;

namespace PeminjamanRuangApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuangController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RuangController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Ruangs.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ruang ruang)
        {
            _context.Ruangs.Add(ruang);
            await _context.SaveChangesAsync();
            return Ok(ruang);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ruang ruangUpdate)
        {
            var ruangLama = await _context.Ruangs.FindAsync(id);
            if (ruangLama == null) return NotFound("Ruangan tidak ditemukan");

            ruangLama.NamaRuangan = ruangUpdate.NamaRuangan;
            ruangLama.Kapasitas = ruangUpdate.Kapasitas;
            ruangLama.Lokasi = ruangUpdate.Lokasi; // Sesuai kolom database kamu

            await _context.SaveChangesAsync();
            return Ok("Data Ruangan Berhasil Diupdate");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ruang = await _context.Ruangs.FindAsync(id);
            if (ruang == null) return NotFound();

            _context.Ruangs.Remove(ruang);
            await _context.SaveChangesAsync();
            return Ok("Ruangan Berhasil Dihapus");
        }
    }
}