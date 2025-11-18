using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion? IConexion = null;

        public PermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        private bool ValidarDescripcionPermisoUnico(string nombrePermiso)
        {

            var rolExistente = this.IConexion!.Roles!
                .FirstOrDefault(x => x.Nombre == nombrePermiso);

            return rolExistente == null;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Permisos? Borrar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Permisos? Guardar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            if (entidad!.Descripcion == null || !ValidarDescripcionPermisoUnico(entidad.Descripcion))
                throw new Exception("El rol no es valido");
            // Operaciones
            this.IConexion!.Permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Listar()
        {
            return this.IConexion!.Permisos!.Take(20).ToList();
        }

        public Permisos? Modificar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            if (entidad!.Descripcion == null || !ValidarDescripcionPermisoUnico(entidad.Descripcion))
                throw new Exception("El rol no es valido");
            // Operaciones
            var entry = this.IConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
