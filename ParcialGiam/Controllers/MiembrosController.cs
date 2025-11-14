using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialGiam.Models;
using ParcialGiam.Models.ParcialGiam.Models;
namespace ParcialGiam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiembrosController : ControllerBase
    {
        private readonly ParcialGiamContext _context;
        public MiembrosController(ParcialGiamContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Miembro>> PostMiembro (Miembro miembro)
        {
            _context.Miembros.Add(miembro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMiembroById), new { id = miembro.Id}, miembro);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Miembro>> GetMiembroById (int id)
        {
            var miembro =await _context.Miembros.FindAsync(id);
            if (miembro == null) 
                return NotFound();
            return miembro;
        }
    }
}
