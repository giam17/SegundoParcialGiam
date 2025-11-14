using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialGiam.Models;
namespace ParcialGiam.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ParcialGiamContext _context;
        public TareasController(ParcialGiamContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTarea()
        {
            return await _context.Tareas.Include(t => t.Responsable).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTareaById), new { id = tarea.Id }, tarea);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
                return BadRequest();
            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return NotFound();
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("ordenar-por-prioridad")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasOrdenadasPorPrioridad()
        {
            return await _context.Tareas
                .OrderBy(t => t.Prioridad)
                .Include(t => t.Responsable)
                .ToListAsync();
        }
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Tarea>>> BuscarPorTitulo([FromQuery] string titulo)
        {
            return await _context.Tareas
                .Where(t => t.Titulo.Contains(titulo))
                .Include(t => t.Responsable)
                .ToListAsync();
        }
        [HttpGet("por-miembro/{idMiembro}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> ListarPorMiembro(int idMiembro)
        {
            return await _context.Tareas
                .Where(t => t.IdResponsable == idMiembro)
                .Include(t => t.Responsable)
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareaById(int id)
        {
            var tarea = await _context.Tareas
                .Include(t => t.Responsable)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (tarea == null)
                return NotFound();
            return Ok(tarea);
        }
    }
}
