using Microsoft.VisualBasic.ApplicationServices;
using Usuarios;
using Tiendas;
using Productos;

namespace WinFormCrud
{
    public partial class FrmPrincipal : Form
    {
        private List<Usuario> usuarios;
        private Usuario usuarioLogueado;
        private Canasta carrito;
        private FrmCarniceria frmCarniceria;
        private FrmAlmacen frmAlmacen;
        private FrmPanaderia frmPanaderia;
        private Almacen almacen;
        private Carniceria carniceria;
        private Panaderia panaderia;
        public FrmPrincipal(Usuario usuarioIngresado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarios = new List<Usuario>();
            this.usuarioLogueado = usuarioIngresado;
            this.carrito = new Canasta();
            this.frmCarniceria = new FrmCarniceria(this.carrito);
            this.frmAlmacen = new FrmAlmacen(this.carrito);
            this.frmPanaderia = new FrmPanaderia(this.carrito);
            this.almacen = new Almacen("25 de mayo 989", 4, "Panificados", new List<ProductosAlmacen>());
            this.carniceria = new Carniceria("Dorrego 1245", 7, "Carne", new List<ProductosCarniceria>(), "Vacuna");
            this.panaderia = new Panaderia("Bustamante 45", 3, "Panificados", new List<ProductosPanaderia>(), "Efectivo");
        }

        public List<Usuario> ListaUsuarios
        {
            get { return this.usuarios; }
            set { this.usuarios = value; }
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            this.usuarios = Datos.DeserializarDatos();
            this.usuarioLogueado = ObtenerUsuario();
            this.LblUsuarioConectado.Text = ObtenerDiaYUsuario();
            List<Producto> productosCarniceria = Datos.DeserializarProductos(@"./productosCarniceria.json");
            List<Producto> productosAlmacen = Datos.DeserializarProductos(@"./productosAlmacen.json");
            List<Producto> productosPanaderia = Datos.DeserializarProductos(@"./productosPanaderia.json");
            this.frmCarniceria.listaCarniceria = Datos.ConvertirProductosCarniceria(productosCarniceria);
            this.frmAlmacen.listaAlmacen = Datos.ConvertirProductosAlmacen(productosAlmacen);
            this.frmPanaderia.listaPanaderia = Datos.ConvertirProductosPanaderia(productosPanaderia);
            this.ActualizarCarritoDeserializado();
            this.frmAlmacen.tipoUsuario = this.usuarioLogueado.Perfil;
            this.frmCarniceria.tipoUsuario = this.usuarioLogueado.Perfil;
            this.frmPanaderia.tipoUsuario = this.usuarioLogueado.Perfil;
        }

        private void ActualizarCarritoDeserializado()
        {
            foreach (ProductosAlmacen prodAlmacen in this.frmAlmacen.listaAlmacen)
            {
                if (prodAlmacen.Cantidad > 0)   
                {
                    int cantidad = prodAlmacen.Cantidad;
                    prodAlmacen.Cantidad = 0;
                    for (int i = 0; i < cantidad; i++) { this.frmAlmacen.carrito += prodAlmacen; }
                }
                else if (prodAlmacen.Cantidad < 0) { prodAlmacen.Cantidad = 0; }
            }

            foreach (ProductosCarniceria prodCarniceria in this.frmCarniceria.listaCarniceria)
            {
                if (prodCarniceria.Cantidad > 0)
                {
                    int cantidad = prodCarniceria.Cantidad;
                    prodCarniceria.Cantidad = 0;
                    for (int i = 0; i < cantidad; i++) { this.frmCarniceria.carrito += prodCarniceria; }
                }
                else if (prodCarniceria.Cantidad < 0) { prodCarniceria.Cantidad = 0; }
            }

            foreach (ProductosPanaderia prodPanaderia in this.frmPanaderia.listaPanaderia)
            {
                if (prodPanaderia.Cantidad > 0)
                {
                    int cantidad = prodPanaderia.Cantidad;
                    prodPanaderia.Cantidad = 0;
                    for (int i = 0; i < cantidad; i++) { this.frmPanaderia.carrito += prodPanaderia; }
                }
                else if (prodPanaderia.Cantidad < 0) { prodPanaderia.Cantidad = 0; }
            }
        }

        /// <summary>
        /// Busca el usuario que se encuentra conectado en la lista de usuarios regustrados.
        /// </summary>
        /// <returns> El usuario con los datos completos </returns>
        private Usuario ObtenerUsuario()
        {
            Usuario usuarioConectado = new Usuario();
            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario == this.usuarioLogueado)
                {
                    usuarioConectado = usuario;
                    break;
                }
            }
            return usuarioConectado;
        }

        private string ObtenerDiaYUsuario()
        {
            DateTime hoy = DateTime.Today;
            DateTime horaActual = DateTime.Now;
            string formatoHora = $"{horaActual.Hour}:{horaActual.Minute}:{horaActual.Second}";
            string usuarioConectado = this.usuarioLogueado.Nombre;
            string diaActual = hoy.ToString("dd-MM-yyyy");
            string diaYUsuario = $"{usuarioConectado} || {diaActual} Hora: {formatoHora}";
            return diaYUsuario;
        }

        private void FormularioPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la aplicacion?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCarniceria_Click(object sender, EventArgs e)
        {
            this.frmCarniceria.ShowDialog();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            this.frmAlmacen.ShowDialog();
        }

        private void btnPanaderia_Click(object sender, EventArgs e)
        {
            this.frmPanaderia.ShowDialog();
        }

        private void btnCanasta_Click(object sender, EventArgs e)
        {
            FrmCanasta canasta = new FrmCanasta(this.carrito);
            canasta.ActualizarCarrito();
            canasta.ShowDialog();
        }

        private void PBoxInfoAlmacen_Click(object sender, EventArgs e)
        {
            string texto = this.almacen.ToString();
            MessageBox.Show(texto, "Informacion de la tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PBoxInfoPanaderia_Click(object sender, EventArgs e)
        {
            string texto = this.panaderia.ToString();
            MessageBox.Show(texto, "Informacion de la tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PBoxInfoCarniceria_Click(object sender, EventArgs e)
        {
            string texto = this.carniceria.ToString();
            MessageBox.Show(texto, "Informacion de la tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Serializa los productos segun tienda Clickeada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerializarProductosAlmacen_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.saveFileDialogDeserializar.ShowDialog() == DialogResult.OK)
            {
                ruta = saveFileDialogDeserializar.FileName;
                Datos.SerializarDatos(this.frmAlmacen.listaAlmacen, ruta);
            }
        }

        private void SerializarProductosCarniceria_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.saveFileDialogDeserializar.ShowDialog() == DialogResult.OK)
            {
                ruta = saveFileDialogDeserializar.FileName;
                Datos.SerializarDatos(this.frmCarniceria.listaCarniceria, ruta);
            }
        }

        private void SerializarProductosPanaderia_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.saveFileDialogDeserializar.ShowDialog() == DialogResult.OK)
            {
                ruta = saveFileDialogDeserializar.FileName;
                Datos.SerializarDatos(this.frmPanaderia.listaPanaderia, ruta);
            }
        }

        /// <summary>
        /// Deserializa los productos segun tienda Clickeada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeserializarProductosAlmacen_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.openFileDialogSerializar.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialogSerializar.FileName;
                List<Producto> lista = Datos.DeserializarProductos(ruta);
                if (lista.Count > 0)
                {
                    this.frmAlmacen.listaAlmacen.Clear();
                    foreach (Producto prod in lista)
                    {
                        ProductosAlmacen nuevoProducto = prod.ConvertirProductoAlmacen();
                        this.frmAlmacen.listaAlmacen.Add(nuevoProducto);
                    }
                }
            }
            this.ActualizarCarritoDeserializado();
        }

        private void DeserializarProductosCarniceria_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.openFileDialogSerializar.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialogSerializar.FileName;
                List<Producto> lista = Datos.DeserializarProductos(ruta);
                
                if (lista.Count > 0)
                {
                    this.frmCarniceria.listaCarniceria.Clear();
                    foreach (Producto prod in lista)
                    {
                        ProductosCarniceria nuevoProducto = prod.ConvertirProductoCarniceria();
                        this.frmCarniceria.listaCarniceria.Add(nuevoProducto);
                    }
                }
            }
            this.ActualizarCarritoDeserializado();
        }

        private void DeserializarProductosPanaderia_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.openFileDialogSerializar.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialogSerializar.FileName;
                List<Producto> lista = Datos.DeserializarProductos(ruta);
                if (lista.Count > 0)
                {
                    this.frmPanaderia.listaPanaderia.Clear();
                    foreach (Producto prod in lista)
                    {
                        ProductosPanaderia nuevoProducto = prod.ConvertirProductoAPanaderia();
                        this.frmPanaderia.listaPanaderia.Add(nuevoProducto);
                    }
                }
            }
            this.ActualizarCarritoDeserializado();
        }
    }
}
