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
        public List<Productos.Producto> productos;
        internal protected Canasta carrito;
        internal protected string? tipoUsuario;
        internal protected Action? delegadoModificar;
        public event Action cantidadMaximaPermitida;

        /// <summary>
        /// Inicializa los atributos y configura por default el perfil en vendedor
        /// </summary>
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
            this.cantidadMaximaPermitida += MostrarMensajeCantidadMaxima;
        }

        /// <summary>
        /// Inicializa los atributos y configura por el perfil en vendedor segun parametro
        /// </summary>
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
            this.cantidadMaximaPermitida += MostrarMensajeCantidadMaxima;
        }

        /// <summary>
        /// Inicializa los atributos y inicia la lista segun parametro
        /// </summary>
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
            this.cantidadMaximaPermitida += MostrarMensajeCantidadMaxima;
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
                lstViewProductos.Items.Add(item);
            }
            foreach (ProductosCarniceria productos in this.listaCarniceria)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                lstViewProductos.Items.Add(item);
            }
            foreach (ProductosPanaderia productos in this.listaPanaderia)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                lstViewProductos.Items.Add(item);
            }
        }

        protected virtual void EliminarProductoDelCarrito(Producto prod) { }

        protected void ActualizarCarrito(Producto nuevoProducto)
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
            if (nuevoProducto is ProductosAlmacen)
            {
                this.carrito.listaAlmacen.Add((ProductosAlmacen)nuevoProducto);
            }
            else if (nuevoProducto is ProductosAlmacen)
            {
                this.carrito.listaPanaderia.Add((ProductosPanaderia)nuevoProducto);
            }
            else
            {
                this.carrito.listaCarniceria.Add((ProductosCarniceria)nuevoProducto);
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
        /// Invoca al evento creado.
        /// </summary>
        protected virtual void DispararEventoCantidadMaximaPermitida()
        {
            this.cantidadMaximaPermitida.Invoke();
        }

        private void MostrarMensajeCantidadMaxima()
        {
            MessageBox.Show("No se admite esa cantidad del producto (máximo 5 y minimo 0)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// Agrega el producto a la lista, base de datos y serializa dependiendo que formulario lo llame.
        /// </summary>
        /// <param name="producto"></param>
        protected void AgregarProducto(Producto producto)
        {
            Type tipoProducto = producto.GetType();
            if (tipoProducto.Name == nameof(ProductosAlmacen))
            {
                this.listaAlmacen.Add((ProductosAlmacen)producto);
                Datos.basesql.AgregarProductoAlmacen((ProductosAlmacen)producto);
                Datos.SerializarDatos(this.listaAlmacen, @"./productosAlmacen.json");
                if (producto.cantidad > 0) { this.carrito.listaAlmacen.Add((ProductosAlmacen)producto); }
            }
            else if (tipoProducto.Name == nameof(ProductosCarniceria))
            {
                this.listaCarniceria.Add((ProductosCarniceria)producto);
                Datos.basesql.AgregarDatoCarniceriaoPanaderia((ProductosCarniceria)producto);
                Datos.SerializarDatos(this.listaCarniceria, @"./productosCarniceria.json");
                if (producto.cantidad > 0) { this.carrito.listaCarniceria.Add((ProductosCarniceria)producto); }
            }
            else
            {
                this.listaPanaderia.Add((ProductosPanaderia)producto);
                Datos.basesql.AgregarDatoCarniceriaoPanaderia((ProductosPanaderia)producto);
                Datos.SerializarDatos(this.listaPanaderia, @"./productosPanaderia.json");
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
            this.ActualizarVisor();
        }

        private void CrearProductoSupervisorMenuItem_Click(object sender, EventArgs e)
        {
            this.CrearProductoStripMenu_Click(sender, e);
        }

        protected virtual void ActualizarProductoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione el producto a modificar", "Ningun producto seleccioado", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void EliminarProductoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione el producto que desea eliminar", "Ningun producto seleccioado", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected virtual void BtnInfoProducto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione un producto para mostrar la informacion","Ningun producto seleccionado",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
