using Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCrud
{
    public partial class FrmAlmacen : FrmProducto
    {
        public FrmAlmacen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
        }
        private void FrmAlmacen_Load(object sender, EventArgs e)
        {

        }

        public override List<Producto> CrearProductos()
        {
            ProductosAlmacen leche = new ProductosAlmacen(0001, "Leche", 1100);
            ProductosAlmacen jugoEnSobre = new ProductosAlmacen(0002, "Jugo clight", 350);
            ProductosAlmacen arroz = new ProductosAlmacen(0003, "Arroz largo", 1200);
            ProductosAlmacen aceite = new ProductosAlmacen(0004, "Aceite", 1700);
            ProductosAlmacen azucar = new ProductosAlmacen(0005, "Azucar", 1000);
            ProductosAlmacen harina = new ProductosAlmacen(0006, "Harina", 900);
            ProductosAlmacen cafe = new ProductosAlmacen(0007, "Cafe molido", 3900);
            ProductosAlmacen arvejas = new ProductosAlmacen(0008, "Arvejas", 800);
            List<ProductosAlmacen> lista = new List<ProductosAlmacen> { leche, jugoEnSobre, arroz, aceite, azucar, harina, cafe, arvejas };
            List<Producto> retorno = ConvertirProductos(lista);
            return retorno;

        }

        private List<Producto> ConvertirProductos(List<ProductosAlmacen> lista)
        {
            List<Productos.Producto> productosCasteados = new List<Productos.Producto>();
            foreach (ProductosAlmacen productos in lista)
            {
                Producto prod = (Producto)productos;
                productosCasteados.Add(prod);
            }
            return productosCasteados;
        }

    }
}
