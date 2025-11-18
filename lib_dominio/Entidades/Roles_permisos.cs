using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Roles_permisos
    {
        public int Id { get; set; }
        public int Rol { get; set; }
        public int Permiso { get; set; }

        [ForeignKey("Rol")]public Roles? _Rol { get; set; }
        [ForeignKey("Permiso")] public Permisos? _Permiso { get; set; }
    }
}
