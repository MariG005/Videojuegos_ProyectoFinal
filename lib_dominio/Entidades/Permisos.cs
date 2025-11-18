using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        [NotMapped] public List<Roles_permisos>? Roles_Permisos { get; set; }
    }
}

