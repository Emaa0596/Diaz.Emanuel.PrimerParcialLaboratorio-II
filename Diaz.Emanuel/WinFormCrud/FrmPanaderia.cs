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
    public partial class FrmPanaderia : FrmTiendas
    {
        public FrmPanaderia(Canasta carrito)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            base.carrito = carrito;
        }

        private void FrmPanaderia_Load(object sender, EventArgs e)
        {
            this.lblPrecio.Text = "Precio por Kilo";
            base.ConfigurarPermisos();
            this.ActualizarVisor();
        }

        /// <summary>
        /// Agrega al carrito el producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            if (base.lstViewProductos.SelectedIndices.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                ProductosPanaderia prod = base.listaPanaderia[indice];
                base.carrito += prod;
                this.ActualizarVisor();
                lstViewProductos.Items[indice].Selected = true;
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Baja la cantidad del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            if (base.lstViewProductos.SelectedIndices.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                ProductosPanaderia prod = base.listaPanaderia[indice];
                base.carrito -= prod;
                this.ActualizarVisor();
                lstViewProductos.Items[indice].Selected = true;
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea eliminar", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Actualiza los productos en el listbox de panaderia
        /// </summary>
        protected override void ActualizarVisor()
        {
            lstViewProductos.Items.Clear();
            foreach (ProductosPanaderia productos in base.listaPanaderia)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                //string item = productos.Mostrar();
                lstViewProductos.Items.Add(item);
            }
        }
        /// <summary>
        /// Guarda los productos ordenados que se encuentran en la lista de la clase padre
        /// </summary>
        /// <param name="lista"></param>
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

        /// <summary>
        /// Invoca al metodo de la clase padre, obtiene la lista ordenada (Segun criterio Clickeado) y actualiza el visor de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
