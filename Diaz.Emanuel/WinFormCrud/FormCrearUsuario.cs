using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCrud
{
    public partial class FormCrearUsuario : Form
    {
        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            bool buscador = false;
            string nombre = this.textBoxNombre.Text;
            string apellido = this.textBoxApellido.Text;
            string email = this.textBoxCorreoElectronico.Text;
            string contraseña = this.textBoxContraseña.Text;
            string perfil = this.comboBoxPerfil.Text;
            Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario(nombre, apellido, email,contraseña, perfil);
            buscador = nuevoUsuario.BuscarUsuarios();
            if( buscador )
            {
                MessageBox.Show("Ya existe un usuario con el mismo correo electronico", "Error", MessageBoxButtons.OK);
            }
            else
            {
                nuevoUsuario.usuarios.Add(nuevoUsuario);
            }
        }
    }
}
