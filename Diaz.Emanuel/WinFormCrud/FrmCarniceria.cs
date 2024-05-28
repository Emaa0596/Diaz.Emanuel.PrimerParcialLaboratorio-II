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
    public partial class FrmCarniceria : FrmProducto
    {
        public FrmCarniceria(Canasta carrito)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            base.productos = new List<Productos.Producto>();
            base.carrito = carrito;
        }

        private void FrmCarniceria_Load(object sender, EventArgs e)
        {
            this.lblPrecio.Text = "Precio por Kilo";
            this.ActualizarVisor();
        }

        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice = base.lstProductos.SelectedIndex;
            if (indice != -1)
            {
                ProductosCarniceria prod = base.listaCarniceria[indice];
                base.carrito += prod;
                //base.productos[indice].Cantidad += 1;
                //int prueba = base.productos[indice].Cantidad; 
                this.ActualizarVisor();
                lstProductos.SelectedIndex = indice;
                //base.btnAgregar_Click(sender, e);
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
                ProductosCarniceria prod = base.listaCarniceria[indice];
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

        public List<ProductosCarniceria> CrearProductos()
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
            return lista;
        }

        protected override void ActualizarVisor()
        {
            lstProductos.Items.Clear();
            foreach (ProductosCarniceria productos in base.listaCarniceria)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
            //base.ActualizarVisor();
        }

        private void ObtenerListaOrdenada(List<Producto> lista)
        {
            List<ProductosCarniceria> listaOrdenada = new List<ProductosCarniceria>();
            foreach (Producto productos in lista)
            {
                ProductosCarniceria prod = (ProductosCarniceria)productos;
                listaOrdenada.Add(prod);
            }
            base.listaCarniceria = listaOrdenada;
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
