namespace ParcialGiam.Models
{
    namespace ParcialGiam.Models
    {
        public enum RolMiembro
        {
            Developer,
            Tester,
            Lider
        }

        public class Miembro
        {
            public int Id { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public RolMiembro Rol { get; set; }
            public ICollection<Tarea> TareasAsignadas { get; set; }
        }
    }

}
