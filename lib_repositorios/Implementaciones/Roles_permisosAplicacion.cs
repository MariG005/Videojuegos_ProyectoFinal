using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Roles_permisosAplicacion : IRoles_permisosAplicacion
    {
        private IConexion? IConexion = null;

        public Roles_permisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Roles_permisos? Borrar(Roles_permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Roles_permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Roles_permisos? Guardar(Roles_permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Roles_permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles_permisos> Listar()
        {
            return this.IConexion!.Roles_permisos!.Take(20).ToList();
        }
        public List<Roles_permisos> ListarPorRol(Roles_permisos? entidad)
        {
            return this.IConexion!.Roles_permisos!
                        .Where(x => x.Rol == entidad!.Rol).ToList();
        }
        public List<Roles_permisos> ListarPorPermiso(Roles_permisos? entidad)
        {
            return this.IConexion!.Roles_permisos!
                        .Where(x => x.Permiso == entidad!.Permiso).ToList();
        }

        public Roles_permisos ? Modificar(Roles_permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry< Roles_permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
