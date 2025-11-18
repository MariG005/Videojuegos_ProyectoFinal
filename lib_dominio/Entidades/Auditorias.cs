using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
        public string? Tabla { get; set; }
        public string? Descripcion { get; set; }
        [ForeignKey("Usuario")]public Usuarios? _Usuario { get; set; }
    }
}

