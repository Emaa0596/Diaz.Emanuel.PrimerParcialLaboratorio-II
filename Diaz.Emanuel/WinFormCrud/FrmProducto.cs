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
    public partial class FrmProducto : Form
    {
        public List<ProductosAlmacen> listaAlmacen;
        public List<ProductosCarniceria> listaCarniceria;
        public List<ProductosPanaderia> listaPanaderia;
        protected Canasta carrito;

        public List<Productos.Producto> productos;
        public FrmProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();

            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
            this.carrito = new Canasta();
        }

        public FrmProducto(List<Productos.Producto> productos)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = productos;

            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
            this.carrito = new Canasta();
        }

        public List<Productos.Producto> ListaProductos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            //ActualizarVisor();
        }




        protected virtual void ActualizarVisor()
        {
            lstProductos.Items.Clear();
            foreach (ProductosCarniceria productos in this.listaCarniceria)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
            foreach (ProductosAlmacen productos in this.listaAlmacen)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
            foreach (ProductosPanaderia productos in this.listaPanaderia)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
        }

        protected virtual void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice = lstProductos.SelectedIndex;
            if (indice != -1)
            {
                //this.productos[indice].Cantidad += 1;
                ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
        }

        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = lstProductos.SelectedIndex;
            if (this.productos[indice].Cantidad > 1)
            {
                //this.productos[indice].Cantidad -= 1;
                ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
            else
            {
                MessageBox.Show("No hay ningun producto de este tipo agregado a la canasta", "Error", MessageBoxButtons.OK);
            }

        }

        
    }
}
