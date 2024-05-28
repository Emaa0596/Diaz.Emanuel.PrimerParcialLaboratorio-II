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
using Tiendas;

namespace WinFormCrud
{
    public partial class FrmPanaderia : FrmProducto
    {
        public FrmPanaderia(Canasta carrito)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
            base.carrito = carrito;
        }

        private void FrmPanaderia_Load(object sender, EventArgs e)
        {
            this.lblPrecio.Text = "Precio por Kilo";
            this.ActualizarVisor();
        }

        public  List<ProductosPanaderia> CrearProductos()
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
            //List<Producto> retorno = ConvertirProductos(lista);
            return lista;

        }

        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice = base.lstProductos.SelectedIndex;
            if (indice != -1)
            {
                ProductosPanaderia prod = base.listaPanaderia[indice];
                base.carrito += prod;
                //base.productos[indice].Cantidad += 1;
                //base.btnAgregar_Click(sender, e);
                this.ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea agregar", "Error", MessageBoxButtons.OK);
            }

        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = base.lstProductos.SelectedIndex;
            if (indice != -1)
            {
                ProductosPanaderia prod = base.listaPanaderia[indice];
                base.carrito -= prod;
                this.ActualizarVisor();
                lstProductos.SelectedIndex = indice;
                //base.productos[indice].Cantidad += 1;
                //int prueba = base.productos[indice].Cantidad; 
                //base.btnEliminar_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea eliminar", "Error", MessageBoxButtons.OK);
            }
        }

        protected override void ActualizarVisor()
        {
            lstProductos.Items.Clear();
            foreach (ProductosPanaderia productos in base.listaPanaderia)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
            //base.ActualizarVisor();
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

        private void ObtenerListaOrdenada(List<Producto> lista)
        {
            List<ProductosPanaderia> listaOrdenada = new List<ProductosPanaderia>();
            foreach (Producto productos in lista)
            {
                ProductosPanaderia prod = (ProductosPanaderia)productos;
                listaOrdenada.Add(prod);
            }
            base.listaPanaderia = listaOrdenada;
        }

        protected override void MenorPrecioAMayorStripMenu_Click(object sender, EventArgs e)
        {
            base.MenorPrecioAMayorStripMenu_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

        protected override void MayorPrecioAMenorStripMenuItem_Click(object sender, EventArgs e)
        {
            base.MayorPrecioAMenorStripMenuItem_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

        protected override void MenorCantidadAMayorMenuItem_Click(object sender, EventArgs e)
        {
            base.MenorCantidadAMayorMenuItem_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

        protected override void MayorCantidadAMenorMenuItem_Click(object sender, EventArgs e)
        {
            base.MayorCantidadAMenorMenuItem_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

    }
}
