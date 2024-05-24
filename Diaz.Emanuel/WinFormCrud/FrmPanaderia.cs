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
    public partial class FrmPanaderia : FrmProducto
    {
        public FrmPanaderia()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
        }

        public override List<Producto> CrearProductos()
        {
            ProductosPanaderia pastaFrola = new ProductosPanaderia(0001, "Pastafrola", 5000, 1);
            ProductosPanaderia bizcochos = new ProductosPanaderia(0002, "Bizcochos", 1200, 0.25f);
            ProductosPanaderia pan = new ProductosPanaderia(0003, "Pan flauta", 1300, 1);
            ProductosPanaderia medialunas = new ProductosPanaderia(0004, "Medialunas", 6000, 1);
            ProductosPanaderia galletitas = new ProductosPanaderia(0005, "Galletitas", 1200, 0.25f);
            ProductosPanaderia cremona = new ProductosPanaderia(0006, "Cremonas", 3000, 1);
            ProductosPanaderia miñones = new ProductosPanaderia(0007, "Miñones", 2500, 1);
            ProductosPanaderia alfajores = new ProductosPanaderia(0008, "Alfajores", 3500, 1);
            List<ProductosPanaderia> lista = new List<ProductosPanaderia> { pastaFrola, bizcochos, pan, medialunas, galletitas, cremona, miñones, alfajores };
            List<Producto> retorno = ConvertirProductos(lista);
            return retorno;

        }

        private List<Producto> ConvertirProductos(List<ProductosPanaderia> lista)
        {
            List<Productos.Producto> productosCasteados = new List<Productos.Producto>();
            foreach (ProductosPanaderia productos in lista)
            {
                Producto prod = (Producto)productos;
                productosCasteados.Add(prod);
            }
            return productosCasteados;
        }

        private void FrmPanaderia_Load(object sender, EventArgs e)
        {
            this.lblPrecio.Text = "Precio por Kilo";
        }
    }
}
