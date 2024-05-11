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
    public partial class FormLogin : Form
    {
        private List<Usuario> usuarios;
        public FormLogin()
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

        private void botonIngresar_Click(object sender, EventArgs e)
        {

            string correoElectronico = this.textBoxUsuario.Text;
            string contraseña = this.textBoxContraseña.Text;
            Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario(correoElectronico, contraseña);
            //List<Usuario> listaDeUsuarios = DeserializarJson();
            bool buscadorUsuarios = Datos.BuscarUsuarios(nuevoUsuario);
            if (buscadorUsuarios)
            {
                this.DialogResult = DialogResult.OK;
                FormularioPrincipal FrmPrincipal = new FormularioPrincipal();
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
            FormCrearUsuario nuevoUsuario = new FormCrearUsuario(this.usuarios);
            nuevoUsuario.ShowDialog();
        }

    }
}
