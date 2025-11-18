using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Paises
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [NotMapped] public List<Usuarios>? Usuarios { get; set; }
    }
}
