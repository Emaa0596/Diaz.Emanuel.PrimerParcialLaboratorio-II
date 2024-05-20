using Microsoft.VisualBasic.ApplicationServices;
using Usuarios;

namespace WinFormCrud
{
    public partial class FrmPrincipal : Form
    {
        private List<Usuario> usuarios;
        private Usuario usuarioLogueado;
        public FrmPrincipal(Usuario usuarioIngresado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarios = new List<Usuario>();
            this.usuarioLogueado = usuarioIngresado;

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

            Image imgFrmPrincipal = new Bitmap(this.BackgroundImage, new Size(694, 460));
            this.BackgroundImage = imgFrmPrincipal;

            Image imgEscaladaAlmacen = new Bitmap(btnAlmacen.Image, new Size(60, 50));
            btnAlmacen.Image = imgEscaladaAlmacen;
            Image imgEscaladaCarne = new Bitmap(btnCarniceria.Image, new Size(70, 50));
            btnCarniceria.Image = imgEscaladaCarne;

            Image imgBtnCanasta = new Bitmap(btnCanasta.Image, new Size(694, 460));
            btnCarniceria.Image = imgBtnCanasta;

            
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

        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {

        }
    }
}
