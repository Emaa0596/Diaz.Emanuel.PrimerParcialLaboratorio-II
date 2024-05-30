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
using Usuarios;

namespace WinFormCrud
{
    public partial class FrmCanasta : Form
    {
        public Canasta carrito;
        public FrmCanasta(Canasta carrito)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.carrito = carrito;
            this.ActualizarCarrito();
        }

        /// <summary>
        /// Actualiza cada producto en el visor de la canasta/carrito
        /// </summary>
        public void ActualizarCarrito()
        {
            lstCanasta.Items.Clear();
            if (this.carrito.listaCarniceria.Count > 0)
            {
                foreach (ProductosCarniceria productos in this.carrito.listaCarniceria)
                {
                    string item = productos.Mostrar();
                    lstCanasta.Items.Add(item);
                }
            }
            if (this.carrito.listaAlmacen.Count > 0)
            {
                foreach (ProductosAlmacen productos in this.carrito.listaAlmacen)
                {
                    string item = productos.Mostrar();
                    lstCanasta.Items.Add(item);
                }
            }
            if (this.carrito.listaPanaderia.Count > 0)
            {
                foreach (ProductosPanaderia productos in this.carrito.listaPanaderia)
                {
                    string item = productos.Mostrar();
                    lstCanasta.Items.Add(item);
                }
            }

            string totalApagar = this.carrito.CalcularTotal();
            this.lblTotalAPagarDouble.Text = totalApagar;
        }

        /// <summary>
        /// Verifica que productos hay actualmente y los agrega a una lista nueva
        /// </summary>
        /// <returns> Retorna la lista </returns>
        private List<Producto> VerificarCanasta()
        {
            List<Producto> listaProductos = new List<Producto>();
            if (this.carrito.listaCarniceria.Count > 0)
            {
                foreach (ProductosCarniceria prod in this.carrito.listaCarniceria)
                {
                    Producto producto = (Producto)prod;
                    listaProductos.Add(producto);
                }
            }
            if (this.carrito.listaPanaderia.Count > 0)
            {
                foreach (ProductosPanaderia prod in this.carrito.listaPanaderia)
                {
                    Producto producto = (Producto)prod;
                    listaProductos.Add(producto);
                }
            }
            if (this.carrito.listaAlmacen.Count > 0)
            {
                foreach (ProductosAlmacen prod in this.carrito.listaAlmacen)
                {
                    Producto producto = (Producto)prod;
                    listaProductos.Add(producto);
                }
            }
            return listaProductos;
        }

        private void menorPrecioAMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Producto> lista = this.VerificarCanasta();
            if (lista.Count > 0)
            {
                lstCanasta.Items.Clear();
                int largoDeLista = lista.Count;
                lista = Ordenamiento.OrdenarPorCriterio(lista, EOrdenamiento.MenorAMayorPrecio);
                foreach (Producto prod in lista)
                {
                    lstCanasta.Items.Add(prod.Mostrar());
                }
            }
            else
            {
                MessageBox.Show("No hay ningun producto en la canasta", "Canasta vacia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Obtiene los productos que hay en la canasta y los ordena segun criterio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mayorPrecioAMenorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Producto> lista = this.VerificarCanasta();
            if (lista.Count > 0)
            {
                lstCanasta.Items.Clear();
                int largoDeLista = lista.Count;
                lista = Ordenamiento.OrdenarPorCriterio(lista, EOrdenamiento.MayorAMenorPrecio);
                foreach (Producto prod in lista)
                {
                    lstCanasta.Items.Add(prod.Mostrar());
                }
            }
            else
            {
                MessageBox.Show("No hay ningun producto en la canasta", "Canasta vacia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MenorCantidadAMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Producto> lista = this.VerificarCanasta();
            if (lista.Count > 0)
            {
                lstCanasta.Items.Clear();
                int largoDeLista = lista.Count;
                lista = Ordenamiento.OrdenarPorCriterio(lista, EOrdenamiento.MenorAMayorCantidad);
                foreach (Producto prod in lista)
                {
                    lstCanasta.Items.Add(prod.Mostrar());
                }
            }
            else
            {
                MessageBox.Show("No hay ningun producto en la canasta", "Canasta vacia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mayorCantidadAMenorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Producto> lista = this.VerificarCanasta();
            if (lista.Count > 0)
            {
                lstCanasta.Items.Clear();
                int largoDeLista = lista.Count;
                lista = Ordenamiento.OrdenarPorCriterio(lista, EOrdenamiento.MayorAMenorCantidad);
                foreach (Producto prod in lista)
                {
                    lstCanasta.Items.Add(prod.Mostrar());
                }
            }
            else
            {
                MessageBox.Show("No hay ningun producto en la canasta", "Canasta vacia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

}
