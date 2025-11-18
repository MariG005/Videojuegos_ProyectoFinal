using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class AuditoriasPruebas
    {
        private readonly IConexion iConexion;
        private readonly IAuditoriasAplicacion AuditoriasAplicacion;
        private Auditorias? Auditorias;

        public AuditoriasPruebas()
        {
            iConexion = new Conexion();
            AuditoriasAplicacion = new AuditoriasAplicacion(iConexion);
            AuditoriasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = AuditoriasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Auditorias = EntidadesNucleo.Auditorias();
            this.AuditoriasAplicacion.Guardar(this.Auditorias);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Auditorias!.Descripcion = "Test";
            this.AuditoriasAplicacion.Modificar(Auditorias);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.AuditoriasAplicacion.Borrar(this.Auditorias);
            return true;
        }
    }
}
