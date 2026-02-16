using Microsoft.AspNetCore.Mvc;
using PeminjamanRuangApi.Models;
using PeminjamanRuangApi.Services;

namespace PeminjamanRuangApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeminjamanController : ControllerBase
    {
        private readonly IPeminjamanService _service; // Gunakan IPeminjamanService

        public PeminjamanController(IPeminjamanService service) // Samakan nama parameter
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> Get() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PeminjamanCreateDto dto) 
        {
            try {
                await _service.AddAsync(dto);
                return Ok(new { message = "Data berhasil ditambahkan!" });
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Peminjaman dataUpdate)
        {
            var success = await _service.UpdateAsync(id, dataUpdate);
            if (!success) return NotFound();
            return Ok("Update Berhasil");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok(new { message = "Data berhasil dihapus!" });
        }
    }
}