namespace Tiendas.Test
{
    [TestClass]
    public class TientaTest
    {
        Almacen almacenUno;
        Almacen almacenDos;

        [TestInitialize]
        public void Inicializador()
        {
            this.almacenUno = new Almacen("25 de mayo 411",3,"Varios", "");
            this.almacenDos = new Almacen("San martin 2342", 2, "Varios", "2x1 en gaseosas");
        }

        /// <summary>
        /// Verifica el Equals sobreescrito en la clase Almacen.
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            Assert.IsFalse(this.almacenUno.Equals(this.almacenDos));
        }
    }
}