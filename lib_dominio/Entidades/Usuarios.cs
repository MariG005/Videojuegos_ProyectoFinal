using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public int Pais { get; set; }

        [NotMapped]public List<Bibliotecas>? Bibliotecas { get; set; }
        [NotMapped] public List<Pagos>? Pagos { get; set; }
        [NotMapped] public List<Resenas>? Resenas { get; set; }
        [NotMapped] public List<Usuarios_roles>? Usuarios_roles { get; set; }
        [NotMapped] public List<CarritoCompras>? CarritoCompras { get; set; }
        [NotMapped] public List<Auditorias>? Auditorias { get; set; }

        [ForeignKey("Pais")] public Paises? _Paises { get; set; }
    }
}