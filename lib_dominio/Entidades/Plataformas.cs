using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Plataformas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [NotMapped] public List<Videojuegos_plataformas>? Videojuegos_plataformas { get; set; }
    }

}