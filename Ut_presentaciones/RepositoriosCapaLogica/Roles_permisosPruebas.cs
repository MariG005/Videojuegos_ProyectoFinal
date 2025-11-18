using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class Roles_permisosPruebas
    {
        private readonly IConexion iConexion;
        private readonly IRoles_permisosAplicacion Roles_permisosAplicacion;
        private Roles_permisos? Roles_permisoss;

        public Roles_permisosPruebas()
        {
            iConexion = new Conexion();
            Roles_permisosAplicacion = new Roles_permisosAplicacion(iConexion);
            Roles_permisosAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(true, ListarRolPrueba());
            Assert.AreEqual(true, ListarPermisoPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, BorrarPrueba());
            Assert.ThrowsException<Exception>(() => BorrarNuloPrueba());
        }

        public bool ListarRolPrueba()
        {
            var lista = Roles_permisosAplicacion.ListarPorRol(this.Roles_permisoss);
            return lista.Count > 0;
        }

        public bool ListarPermisoPrueba()
        {
            var lista = Roles_permisosAplicacion.ListarPorPermiso(this.Roles_permisoss);
            return lista.Count > 0;
        }


        public bool ListarPrueba()
        {
            var lista = Roles_permisosAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Roles_permisoss = EntidadesNucleo.Roles_permisos();
            this.Roles_permisosAplicacion.Guardar(this.Roles_permisoss);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Roles_permisoss!.Rol = 3;
            this.Roles_permisoss!.Permiso = 3;
            this.Roles_permisosAplicacion.Modificar(Roles_permisoss);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.Roles_permisosAplicacion.Borrar(this.Roles_permisoss);
            return true;
        }

        public void BorrarNuloPrueba()
        {
            Roles_permisosAplicacion!.Borrar(null);
        }
    }
}
