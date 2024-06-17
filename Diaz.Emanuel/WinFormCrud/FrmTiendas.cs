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
    public partial class FrmTiendas : Form
    {
        public List<ProductosAlmacen> listaAlmacen;
        public List<ProductosCarniceria> listaCarniceria;
        public List<ProductosPanaderia> listaPanaderia;
        protected Canasta carrito;
        public List<Productos.Producto> productos;
        internal protected string tipoUsuario;
        public FrmTiendas()
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

        public FrmTiendas(string tipoDeUsuario)
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

        public FrmTiendas(List<Productos.Producto> productos)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = productos;
            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
            this.carrito = new Canasta();
            this.tipoUsuario = "Vendedor";
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
            lstViewProductos.Items.Clear();
            foreach (ProductosAlmacen productos in this.listaAlmacen)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                //string item = productos.Mostrar();
                lstViewProductos.Items.Add(item);
            }
            foreach (ProductosCarniceria productos in this.listaCarniceria)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                //string item = productos.Mostrar();
                lstViewProductos.Items.Add(item);
            }
            foreach (ProductosPanaderia productos in this.listaPanaderia)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                //string item = productos.Mostrar();
                lstViewProductos.Items.Add(item);
            }
        }

        /// <summary>
        /// Se Aplica polimorfismo en clases derivadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.lstViewProductos.SelectedIndices.Count > 0)
            {
                ActualizarVisor();
            }
        }

        /// <summary>
        /// Se Aplica polimorfismo en clases derivadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstViewProductos.SelectedIndices.Count > 0)
            {
                ActualizarVisor();
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

        protected virtual void CrearProductoStripMenu_Click(object sender, EventArgs e)
        {
            FrmProducto nuevoProducto = new FrmProducto();
            DialogResult dialogo = nuevoProducto.ShowDialog();
            if (nuevoProducto.Productos != null && dialogo == DialogResult.OK)
            {
                Producto productoAgregado = nuevoProducto.Productos;
                Type tipoProducto = this.GetType();
                switch (tipoProducto.Name)
                {
                    case nameof(FrmCarniceria):
                        ProductosCarniceria productoCarniceria = new ProductosCarniceria(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad, 1);
                        this.listaCarniceria.Add(productoCarniceria);
                        if (productoCarniceria.Cantidad > 0)
                        {
                            this.carrito.listaCarniceria.Add(productoCarniceria);
                        }
                        break;
                    case nameof(FrmAlmacen):
                        ProductosAlmacen productoAlmacen = new ProductosAlmacen(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad);
                        this.listaAlmacen.Add(productoAlmacen);
                        if (productoAlmacen.Cantidad > 0)
                        {
                            this.carrito.listaAlmacen.Add(productoAlmacen);
                        }
                        break;
                    case nameof(FrmPanaderia):
                        ProductosPanaderia productoPanaderia = new ProductosPanaderia(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad, 1);
                        this.listaPanaderia.Add(productoPanaderia);
                        if (productoPanaderia.Cantidad > 0)
                        {
                            this.carrito.listaPanaderia.Add(productoPanaderia);
                        }
                        break;
                }
            }

            this.ActualizarVisor();
            //actualizar canasta
        }

        private void CrearProductoSupervisorMenuItem_Click(object sender, EventArgs e)
        {
            this.CrearProductoStripMenu_Click(sender, e);
        }

        private void ActualizarProductoMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstViewProductos.SelectedIndices.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                Type tipoProducto = this.GetType();
                switch (tipoProducto.Name)
                {
                    case nameof(FrmAlmacen):
                        ProductosAlmacen productoAModificar = this.listaAlmacen[indice];
                        FrmProducto prod = new FrmProducto(productoAModificar);
                        DialogResult resultado = prod.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            this.listaAlmacen[indice] = new ProductosAlmacen(prod.Productos.Codigo, prod.Productos.Nombre, prod.Productos.Precio, prod.Productos.Cantidad);
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmCarniceria):
                        ProductosCarniceria productoAModificarCarniceria = this.listaCarniceria[indice];
                        FrmProducto prodCarniceria = new FrmProducto(productoAModificarCarniceria);
                        DialogResult resultadoCarniceria = prodCarniceria.ShowDialog();
                        if (resultadoCarniceria == DialogResult.OK)
                        {
                            this.listaCarniceria[indice] = new ProductosCarniceria(prodCarniceria.Productos.Codigo, prodCarniceria.Productos.Nombre, prodCarniceria.Productos.Precio, prodCarniceria.Productos.Cantidad,1);
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmPanaderia):
                        ProductosCarniceria productoAModificarPanaderia = this.listaCarniceria[indice];
                        FrmProducto prodPanaderia = new FrmProducto(productoAModificarPanaderia);
                        DialogResult resultadoPanaderia = prodPanaderia.ShowDialog();
                        if (resultadoPanaderia == DialogResult.OK)
                        {
                            this.listaPanaderia[indice] = new ProductosPanaderia(prodPanaderia.Productos.Codigo, prodPanaderia.Productos.Nombre, prodPanaderia.Productos.Precio, prodPanaderia.Productos.Cantidad, 1);
                            this.ActualizarVisor();
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el producto a modificar", "ningun producto seleccioado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ActualizarProductoMenuItem_Click(sender, e);
        }

        private void EliminarProductoMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstViewProductos.SelectedIndices.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                Type tipoProducto = this.GetType();
                switch (tipoProducto.Name)
                {
                    case nameof(FrmAlmacen):
                        ProductosAlmacen productoAModificar = this.listaAlmacen[indice];
                        FrmProducto prod = new FrmProducto(productoAModificar);
                        DialogResult resultado = prod.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            this.listaAlmacen.Remove(productoAModificar);
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmCarniceria):
                        ProductosCarniceria productoAModificarCarniceria = this.listaCarniceria[indice];
                        FrmProducto prodCarniceria = new FrmProducto(productoAModificarCarniceria);
                        DialogResult resultadoCarniceria = prodCarniceria.ShowDialog();
                        if (resultadoCarniceria == DialogResult.OK)
                        {
                            this.listaCarniceria[indice] = new ProductosCarniceria(prodCarniceria.Productos.Codigo, prodCarniceria.Productos.Nombre, prodCarniceria.Productos.Precio, prodCarniceria.Productos.Cantidad, 1);
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmPanaderia):
                        ProductosPanaderia productoAModificarPanaderia = this.listaPanaderia[indice];
                        FrmProducto prodPanaderia = new FrmProducto(productoAModificarPanaderia);
                        DialogResult resultadoPanaderia = prodPanaderia.ShowDialog();
                        if (resultadoPanaderia == DialogResult.OK)
                        {
                            this.listaPanaderia[indice] = new ProductosPanaderia(prodPanaderia.Productos.Codigo, prodPanaderia.Productos.Nombre, prodPanaderia.Productos.Precio, prodPanaderia.Productos.Cantidad, 1);
                            this.ActualizarVisor();
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el producto a eliminar", "ningun producto seleccioado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
