using Microsoft.EntityFrameworkCore;
using ParcialGiam.Models.ParcialGiam.Models;

namespace ParcialGiam.Models
{

    public class ParcialGiamContext : DbContext
    {
        public ParcialGiamContext(DbContextOptions<ParcialGiamContext> options)
            : base(options)
        {
        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
    }
}
