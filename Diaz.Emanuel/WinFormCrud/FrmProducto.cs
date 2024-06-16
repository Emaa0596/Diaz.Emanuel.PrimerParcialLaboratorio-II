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
    public partial class FrmProducto : Form
    {
        public List<ProductosAlmacen> listaAlmacen;
        public List<ProductosCarniceria> listaCarniceria;
        public List<ProductosPanaderia> listaPanaderia;
        protected Canasta carrito;
        public List<Productos.Producto> productos;
        internal protected string tipoUsuario;
        public FrmProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
            this.carrito = new Canasta();
            this.tipoUsuario = "Vendedor";
        }

        public FrmProducto(string tipoDeUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
            this.carrito = new Canasta();
            this.tipoUsuario = tipoDeUsuario;
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

        protected void ConfigurarPermisos()
        {
            switch (this.tipoUsuario)
            {
                case "Vendedor":
                    this.AdministradorMenuStrip.Enabled = false;
                    this.SupervisorMenuStrip.Enabled = false;
                    break;
                case "Supervisor":
                    this.AdministradorMenuStrip.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Actualiza la lista de productos de cada tienda
        /// </summary>
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

        /// <summary>
        /// Se Aplica polimorfismo en clases derivadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice = lstProductos.SelectedIndex;
            if (indice != -1)
            {
                ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
        }

        /// <summary>
        /// Se Aplica polimorfismo en clases derivadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = lstProductos.SelectedIndex;
            if (this.productos[indice].Cantidad > 1)
            {
                ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
            else
            {
                MessageBox.Show("No hay ningun producto de este tipo agregado a la canasta", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Castea los productos dependiendo que formulario invoca al metodo
        /// y los agrega a la lista de productos.
        /// </summary>
        protected void ConvertirProductosDerivados()
        {
            this.productos = new List<Producto>();
            Type tipoProducto = this.GetType();
            switch (tipoProducto.Name)
            {
                case nameof(FrmCarniceria):
                    foreach (ProductosCarniceria productosCarniceria in this.listaCarniceria)
                    {
                        this.productos.Add((Producto)productosCarniceria);
                    }
                    break;

                case nameof(FrmAlmacen):
                    foreach (ProductosAlmacen productosAlmacen in this.listaAlmacen)
                    {
                        this.productos.Add((Producto)productosAlmacen);
                    }
                    break;

                case nameof(FrmPanaderia):
                    foreach (ProductosPanaderia productosPanaderia in this.listaPanaderia)
                    {
                        this.productos.Add((Producto)productosPanaderia);
                    }
                    break;
            }
        }

        /// <summary>
        /// Invoca a metodo estatico de ordenamiento y los guarda en la lista de productos ordenados,segun criterio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MenorPrecioAMayorStripMenu_Click(object sender, EventArgs e)
        {
            ConvertirProductosDerivados();
            this.productos = Ordenamiento.OrdenarPorCriterio(this.productos, EOrdenamiento.MenorAMayorPrecio);
        }

        protected virtual void MayorPrecioAMenorStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertirProductosDerivados();
            this.productos = Ordenamiento.OrdenarPorCriterio(this.productos, EOrdenamiento.MayorAMenorPrecio);
        }

        protected virtual void MenorCantidadAMayorMenuItem_Click(object sender, EventArgs e)
        {
            ConvertirProductosDerivados();
            this.productos = Ordenamiento.OrdenarPorCriterio(this.productos, EOrdenamiento.MenorAMayorCantidad);
        }

        protected virtual void MayorCantidadAMenorMenuItem_Click(object sender, EventArgs e)
        {
            ConvertirProductosDerivados();
            this.productos = Ordenamiento.OrdenarPorCriterio(this.productos, EOrdenamiento.MayorAMenorCantidad);
        }

        private void crearProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entraste a crear");
        }
    }
}
