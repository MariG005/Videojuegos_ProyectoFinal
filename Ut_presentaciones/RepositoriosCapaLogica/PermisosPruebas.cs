using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class PermisosPruebas
    {
        private readonly IConexion iConexion;
        private readonly IPermisosAplicacion PermisosAplicacion;
        private Permisos? Permisos;

        public PermisosPruebas()
        {
            iConexion = new Conexion();
            PermisosAplicacion = new PermisosAplicacion(iConexion);
            PermisosAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, BorrarPrueba());
        }

        public bool ListarPrueba()
        {
            var lista = PermisosAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Permisos = EntidadesNucleo.Permisos();
            this.PermisosAplicacion.Guardar(this.Permisos);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Permisos!.Descripcion = "Test";
            this.PermisosAplicacion.Modificar(Permisos);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.PermisosAplicacion.Borrar(this.Permisos);
            return true;
        }
    }
}
