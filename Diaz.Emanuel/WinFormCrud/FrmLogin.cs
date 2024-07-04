using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuarios;

namespace WinFormCrud
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;

        /// <summary>
        /// Inicializa el atributo y el form.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarios = new List<Usuario>();
        }

        public List<Usuario> Usuarios { get { return this.usuarios; } }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.usuarios = Datos.DeserializarDatos();
        }

        /// <summary>
        /// Valida si el usuario y contraseña existe y son correctos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonIngresar_Click(object sender, EventArgs e)
        {
            string correoElectronico = this.textBoxUsuario.Text;
            string contraseña = this.textBoxContraseña.Text;
            Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario(correoElectronico, contraseña);
            bool buscadorUsuarios = Datos.BuscarUsuarios(nuevoUsuario);
            if (buscadorUsuarios)
            {
                FrmPrincipal FrmPrincipal = new FrmPrincipal(nuevoUsuario);
                this.Hide();
                DialogResult cierreApp = FrmPrincipal.ShowDialog();
                if (cierreApp == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("El usuario no existe o la clave es incorrecta", "Usuario no encontrado", MessageBoxButtons.OK);
            }
        }

        private void linkCrearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCrearUsuario nuevoUsuario = new FrmCrearUsuario();
            nuevoUsuario.ShowDialog();
        }

    }
}
