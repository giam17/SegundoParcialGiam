using ParcialGiam.Models.ParcialGiam.Models;

namespace ParcialGiam.Models
{
    public enum EstadoTarea
    {
        ToDo,
        InProgress,
        Done
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }

    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoTarea Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public int IdResponsable { get; set; }
        public Miembro Responsable { get; set; }
    }
}
