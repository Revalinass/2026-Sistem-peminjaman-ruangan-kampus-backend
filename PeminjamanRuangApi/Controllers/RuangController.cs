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
        public async Task<IActionResult> Post(Ruang ruang)
        {
            _context.Ruangs.Add(ruang);
            await _context.SaveChangesAsync();
            return Ok(ruang);
        }
    }
}
