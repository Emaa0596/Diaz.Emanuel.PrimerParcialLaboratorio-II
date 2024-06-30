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
        internal protected Canasta carrito;
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

        private void ActualizarCarrito(Producto nuevoProducto)
        {
            bool coincidencia = false;
            if (this.carrito.listaAlmacen.Count > 0)
            {
                for (int i = 0; i < this.carrito.listaAlmacen.Count; i++)
                {
                    if (this.carrito.listaAlmacen[i] == nuevoProducto)
                    {
                        this.carrito.listaAlmacen[i] = (ProductosAlmacen)nuevoProducto;
                        coincidencia = true;
                    }
                }
            }
            if (this.carrito.listaCarniceria.Count > 0 && !coincidencia)
            {
                for (int i = 0; i < this.carrito.listaCarniceria.Count; i++)
                {
                    if (this.carrito.listaCarniceria[i] == nuevoProducto)
                    {
                        this.carrito.listaCarniceria[i] = (ProductosCarniceria)nuevoProducto;
                        coincidencia = true;
                    }
                }
            }
            if (this.carrito.listaPanaderia.Count > 0 && !coincidencia)
            {
                for (int i = 0; i < this.carrito.listaPanaderia.Count; i++)
                {
                    if (this.carrito.listaPanaderia[i] == nuevoProducto)
                    {
                        this.carrito.listaPanaderia[i] = (ProductosPanaderia)nuevoProducto;
                        coincidencia = true;
                    }
                }
            }
            if (!coincidencia) { this.AgregarProductoAlCarrito(nuevoProducto); }
        }

        private void AgregarProductoAlCarrito(Producto nuevoProducto)
        {
            Type tipoProducto = typeof(Producto);
            switch (tipoProducto.Name)
            {
                case nameof(ProductosCarniceria):
                    this.carrito.listaCarniceria.Add((ProductosCarniceria)nuevoProducto);
                    break;
                case nameof(ProductosAlmacen):
                    this.carrito.listaAlmacen.Add((ProductosAlmacen)nuevoProducto);
                    break;
                case nameof(ProductosPanaderia):
                    this.carrito.listaPanaderia.Add((ProductosPanaderia)nuevoProducto);
                    break;
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

        private void AgregarProducto(Producto producto)
        {
            Type tipoProducto = producto.GetType();
            if (tipoProducto.Name == nameof(ProductosAlmacen))
            {
                this.listaAlmacen.Add((ProductosAlmacen)producto);
                Datos.basesql.AgregarProductoAlmacen((ProductosAlmacen)producto);
                if (producto.cantidad > 0) { this.carrito.listaAlmacen.Add((ProductosAlmacen)producto); }
            }
            else if (tipoProducto.Name == nameof(ProductosCarniceria))
            {
                this.listaCarniceria.Add((ProductosCarniceria)producto);
                Datos.basesql.AgregarDatoCarniceriaoPanaderia((ProductosCarniceria)producto);
                if (producto.cantidad > 0) { this.carrito.listaCarniceria.Add((ProductosCarniceria)producto); }
            }
            else
            {
                this.listaPanaderia.Add((ProductosPanaderia)producto);
                Datos.basesql.AgregarDatoCarniceriaoPanaderia((ProductosPanaderia)producto);
                if (producto.cantidad > 0) { this.carrito.listaPanaderia.Add((ProductosPanaderia)producto); }
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
                        bool coincidenciaCarniceria = false;
                        ProductosCarniceria productoCarniceria = new ProductosCarniceria(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad, 1);
                        foreach (Producto prod in this.listaCarniceria)
                        {
                            if (prod == productoCarniceria)
                            {
                                coincidenciaCarniceria = true;
                            }
                        }
                        if (!coincidenciaCarniceria)
                        {
                            this.AgregarProducto(productoCarniceria);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe ese producto","Coincidencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        break;

                    case nameof(FrmAlmacen):
                        bool coincidenciaAlmacen = false;
                        ProductosAlmacen productoAlmacen = new ProductosAlmacen(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad);
                        foreach (Producto prod in this.listaAlmacen)
                        {
                            if (prod == productoAlmacen)
                            {
                                coincidenciaAlmacen = true;
                            }
                        }
                        if (!coincidenciaAlmacen)
                        {
                            this.AgregarProducto(productoAlmacen);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe ese producto", "Coincidencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case nameof(FrmPanaderia):
                        bool coincidenciaPanaderia = false;
                        ProductosPanaderia productoPanaderia = new ProductosPanaderia(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad, 1);
                        foreach (Producto prod in this.listaPanaderia)
                        {
                            if (prod == productoPanaderia)
                            {
                                coincidenciaPanaderia = true;
                            }
                        }
                        if (!coincidenciaPanaderia)
                        {
                            this.AgregarProducto(productoPanaderia);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe ese producto", "Coincidencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }

            this.ActualizarVisor();
            
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
                            ProductosAlmacen productoModificado = new ProductosAlmacen(prod.Productos.Codigo, prod.Productos.Nombre, prod.Productos.Precio, prod.Productos.Cantidad);
                            Datos.basesql.ModificarProductoAlmacen(productoModificado);
                            this.listaAlmacen = Datos.basesql.ObtenerListaAlmacen();
                            this.ActualizarCarrito(productoModificado);
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmCarniceria):
                        ProductosCarniceria productoAModificarCarniceria = this.listaCarniceria[indice];
                        FrmProducto prodCarniceria = new FrmProducto(productoAModificarCarniceria);
                        DialogResult resultadoCarniceria = prodCarniceria.ShowDialog();
                        if (resultadoCarniceria == DialogResult.OK)
                        {
                            ProductosCarniceria productoModificado = new ProductosCarniceria(prodCarniceria.Productos.Codigo, prodCarniceria.Productos.Nombre, prodCarniceria.Productos.Precio, prodCarniceria.Productos.Cantidad, 1);
                            Datos.basesql.ModificarProductoCarniceriaOPanaderia(productoModificado);
                            this.listaCarniceria = Datos.basesql.ObtenerListaCarniceria();
                            this.ActualizarCarrito(productoModificado);
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmPanaderia):
                        ProductosCarniceria productoAModificarPanaderia = this.listaPanaderia[indice];
                        FrmProducto prodPanaderia = new FrmProducto(productoAModificarPanaderia);
                        DialogResult resultadoPanaderia = prodPanaderia.ShowDialog();
                        if (resultadoPanaderia == DialogResult.OK)
                        {
                            ProductosPanaderia productoModificado = new ProductosPanaderia(prodPanaderia.Productos.Codigo, prodPanaderia.Productos.Nombre, prodPanaderia.Productos.Precio, prodPanaderia.Productos.Cantidad, 1);
                            Datos.basesql.ModificarProductoCarniceriaOPanaderia(productoModificado);
                            this.listaPanaderia = Datos.basesql.ObtenerListaPanaderia();
                            this.ActualizarCarrito(productoModificado);

                            //CORREGIR ESTO!!!
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
                            Datos.basesql.EliminarProducto(productoAModificar.Codigo, "productosAlmacen");
                            this.listaAlmacen = Datos.basesql.ObtenerListaAlmacen();
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmCarniceria):
                        ProductosCarniceria productoAModificarCarniceria = this.listaCarniceria[indice];
                        FrmProducto prodCarniceria = new FrmProducto(productoAModificarCarniceria);
                        DialogResult resultadoCarniceria = prodCarniceria.ShowDialog();
                        if (resultadoCarniceria == DialogResult.OK)
                        {
                            Datos.basesql.EliminarProducto(productoAModificarCarniceria.Codigo, "productosCarniceria");
                            this.listaCarniceria = Datos.basesql.ObtenerListaCarniceria();
                            this.ActualizarVisor();
                        }
                        break;
                    case nameof(FrmPanaderia):
                        ProductosPanaderia productoAModificarPanaderia = this.listaPanaderia[indice];
                        FrmProducto prodPanaderia = new FrmProducto(productoAModificarPanaderia);
                        DialogResult resultadoPanaderia = prodPanaderia.ShowDialog();
                        if (resultadoPanaderia == DialogResult.OK)
                        {
                            
                            Datos.basesql.EliminarProducto(productoAModificarPanaderia.Codigo, "productosPanaderia");
                            this.listaPanaderia = Datos.basesql.ObtenerListaPanaderia();
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
