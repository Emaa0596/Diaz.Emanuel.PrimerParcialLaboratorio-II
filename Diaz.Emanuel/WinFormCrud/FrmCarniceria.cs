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
    public partial class FrmCarniceria : FrmProducto
    {
        public FrmCarniceria()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
            
        }

        private void FrmCarniceria_Load(object sender, EventArgs e)
        {
            this.lblPrecio.Text = "Precio por Kilo";
        }

        public override List<Producto> CrearProductos()
        {
            ProductosCarniceria nalga = new ProductosCarniceria(0001, "Nalga", 7000, 1);
            ProductosCarniceria cuadrada = new ProductosCarniceria(0002, "Cuadrada", 6500, 1);
            ProductosCarniceria asado = new ProductosCarniceria(0003, "Asado", 7500, 1);
            ProductosCarniceria paleta = new ProductosCarniceria(0004, "Paleta", 6000, 1);
            ProductosCarniceria chorizo = new ProductosCarniceria(0005, "Chorizo", 5000, 1);
            ProductosCarniceria morcilla = new ProductosCarniceria(0006, "Morcilla", 4000, 1);
            ProductosCarniceria chinchulin = new ProductosCarniceria(0007, "Chinchulin", 4000, 1);
            ProductosCarniceria bolaDeLomo = new ProductosCarniceria(0008, "Bola de lomo", 7000, 1);
            ProductosCarniceria carnePicada = new ProductosCarniceria(0009, "Carne picada", 5000, 1);
            List<ProductosCarniceria> lista = new List<ProductosCarniceria> { nalga, chorizo, morcilla, chinchulin, bolaDeLomo, carnePicada, paleta, asado, cuadrada };
            List<Producto> retorno = ConvertirProductos(lista);
            return retorno;
        }

        private List<Producto> ConvertirProductos(List<ProductosCarniceria> lista)
        {
            List<Productos.Producto> productosCasteados = new List<Productos.Producto>();
            foreach (ProductosCarniceria productos in lista)
            {
                Producto prod = (Producto)productos;
                productosCasteados.Add(prod);
            }
            return productosCasteados;
        }

        
    }
}
