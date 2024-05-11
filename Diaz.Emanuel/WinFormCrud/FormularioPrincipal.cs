using Microsoft.VisualBasic.ApplicationServices;
using Usuarios;

namespace WinFormCrud
{
    public partial class FormularioPrincipal : Form
    {
        private List<Usuario> usuarios;
        public FormularioPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarios = new List<Usuario>();

        }


        public List<Usuario> ListaUsuarios
        {
            get { return this.usuarios; }
            set { this.usuarios = value; }
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            this.usuarios = Datos.DeserializarDatos();
            //Usuario nuevoUsuario = new Usuario("Emanuel", "Diaz", "emanueldiaz0596@gmail.com", "1234", "Administrador");
            //this.usuarios.Add(nuevoUsuario);
            //SerializarDatos();
            //FormLogin UsuarioLogueado = new FormLogin();
            //DialogResult logueo = UsuarioLogueado.ShowDialog();
            //if(logueo != DialogResult.OK)
            //{
            //    //if( MessageBox.Show("Desea salir de la aplicacion?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //    //{
            //    //     this.Dispose();
            //    //}
            //    UsuarioLogueado = new FormLogin();
            //    logueo = UsuarioLogueado.ShowDialog();
            //    this.Dispose();
            //}
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

        private void FormularioPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la aplicacion?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else 
            {
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
