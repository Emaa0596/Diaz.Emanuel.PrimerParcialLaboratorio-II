using Productos;
using Usuarios;

namespace Datos.Test
{
    [TestClass]
    public class SerializarDatosTest
    {
        List<Producto>? lista;

        [TestInitialize]
        public void Inicializar()
        {
            lista = new List<Producto>() { new ProductosAlmacen(1235,"alfajores",1000,0) };
        }

        /// <summary>
        /// Verifica que se serialice correctamente la lista creada en el initialize. una vez que termina, borra el archivo.
        /// </summary>
        [TestMethod]
        public void TestMetodoSerializar()
        {
            string ruta = "./pruebaSerializar";
            Usuarios.Datos.SerializarDatos(this.lista, ruta);
            string contenidoArchivo = File.ReadAllText(ruta);
            Assert.IsTrue(contenidoArchivo.Contains("alfajores"));
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
        }
    }
}