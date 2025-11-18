using lib_dominio.Entidades;
namespace lib_repositorios.Interfaces
{
    public interface IRoles_permisosAplicacion
    {
        void Configurar(string StringConexion);
        List<Roles_permisos> Listar();
        List<Roles_permisos> ListarPorRol(Roles_permisos? entidad);
        List<Roles_permisos> ListarPorPermiso(Roles_permisos? entidad);
        Roles_permisos? Guardar(Roles_permisos? entidad);
        Roles_permisos? Modificar(Roles_permisos? entidad);
        Roles_permisos? Borrar(Roles_permisos? entidad);
    }
}