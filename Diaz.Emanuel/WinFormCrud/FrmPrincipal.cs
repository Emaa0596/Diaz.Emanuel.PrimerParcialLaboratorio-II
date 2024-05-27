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
        private bool banderaAlmacen;
        private bool banderaCarniceria;
        private bool banderaPanaderia;
        public FrmPrincipal(Usuario usuarioIngresado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarios = new List<Usuario>();
            this.usuarioLogueado = usuarioIngresado;
            this.carrito = new Canasta();
            this.banderaAlmacen = false;
            this.banderaCarniceria = false;
            this.banderaPanaderia = false;
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
        }

        public bool BuscarUsuarios(Usuario usuario)
        {
            bool coincidencia = false;
            foreach (Usuario usuarioGuardado in this.usuarios)
            {
                if (usuarioGuardado.correoElectronico == usuario.correoElectronico && usuarioGuardado.clave == usuario.clave)
                {
                    coincidencia = true;
                }
            }
            return coincidencia;
        }

        private Usuario ObtenerUsuario()
        {
            Usuario usuarioConectado = new Usuario();
            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario.correoElectronico == this.usuarioLogueado.correoElectronico)
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
            string usuarioConectado = this.usuarioLogueado.Nombre;
            string diaActual = hoy.ToString("dd-MM-yyyy");
            string diaYUsuario = $"{usuarioConectado} || {diaActual}";
            return diaYUsuario;

        }

        private void FormularioPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("�Desea cerrar la aplicacion?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
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
            if (!this.banderaCarniceria)
            {
                //this.frmCarniceria.listaCarniceria = this.frmCarniceria.CrearProductos();
                this.banderaCarniceria = true;
                this.frmCarniceria.ShowDialog();
            }
            else
            {
                this.frmCarniceria.ShowDialog();
            }


        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            if (!this.banderaAlmacen)
            {
                //this.frmAlmacen.listaAlmacen = this.frmAlmacen.CrearProductos();
                this.banderaAlmacen = true;
                this.frmAlmacen.ShowDialog();
            }
            else
            {
                this.frmAlmacen.ShowDialog();
            }
        }

        private void btnPanaderia_Click(object sender, EventArgs e)
        {
            if (!this.banderaPanaderia)
            {
                //this.frmPanaderia.listaPanaderia = this.frmPanaderia.CrearProductos();
                this.banderaPanaderia = true;
                this.frmPanaderia.ShowDialog();
            }
            else
            {
                this.frmPanaderia.ShowDialog();
            }
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

        private void DeserializarProductosAlmacen_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.openFileDialogSerializar.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialogSerializar.FileName;
                List<Producto> lista = Datos.DeserializarProductos(ruta);
                foreach (Producto prod in lista)
                {
                    //Arreglar, hacer converciones 
                    this.frmAlmacen.listaAlmacen.Add((ProductosAlmacen)prod);
                }
            }
        }

        private void DeserializarProductosCarniceria_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.openFileDialogSerializar.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialogSerializar.FileName;
                List<Producto> lista = Datos.DeserializarProductos(ruta);
                foreach (Producto prod in lista)
                {
                    this.frmCarniceria.listaCarniceria.Add((ProductosCarniceria)prod);
                }
            }
        }

        private void DeserializarProductosPanaderia_Click(object sender, EventArgs e)
        {
            string ruta;
            if (this.openFileDialogSerializar.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialogSerializar.FileName;
                List<Producto> lista = Datos.DeserializarProductos(ruta);
                foreach (Producto prod in lista)
                {
                    this.frmPanaderia.listaPanaderia.Add((ProductosPanaderia)prod);
                }
            }
        }
    }
}
