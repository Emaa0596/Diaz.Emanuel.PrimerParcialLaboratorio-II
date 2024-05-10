using System;
using System.Collections;
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
    public partial class FormCrearUsuario : Form
    {   
        List<Usuario> usuarios;
        public FormCrearUsuario()
        {
            InitializeComponent();
            this.usuarios = new List<Usuario>();
        }

        public FormCrearUsuario(List<Usuario> listaDeUsuarios)
        {
            InitializeComponent();
            this.usuarios = listaDeUsuarios;
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
            buscador = BuscarUsuarios(nuevoUsuario);
            if( buscador )
            {
                MessageBox.Show("Ya existe un usuario con el mismo correo electronico", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Datos.AgregarUsuario(nuevoUsuario);
                Datos.SerializarDatos(nuevoUsuario);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool BuscarUsuarios(Usuario nuevoUsuario)
        {
            bool coincidencia = false;
            foreach (Usuario usuarioGuardado in this.usuarios)
            {
                if (usuarioGuardado.correoElectronico == nuevoUsuario.correoElectronico)
                {
                    coincidencia = true;
                }
            }
            return coincidencia;
        }
    }
}
