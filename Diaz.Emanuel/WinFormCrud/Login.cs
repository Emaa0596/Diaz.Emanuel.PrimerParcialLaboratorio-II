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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            bool buscadorUsuarios = false;
            string correoElectronico = this.textBoxUsuario.Text;
            string contraseña = this.textBoxContraseña.Text;
            Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario(correoElectronico, contraseña);
            buscadorUsuarios = nuevoUsuario.BuscarUsuarios();
            if (buscadorUsuarios)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario no existe", "Usuario no encontrado", MessageBoxButtons.OK);
            }
        }

        private void linkCrearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCrearUsuario nuevoUsuario = new FormCrearUsuario();
            nuevoUsuario.ShowDialog();
        }

        private void buttonSerializar_Click(object sender, EventArgs e)
        {
            using(StreamWriter json = new StreamWriter(".\\Usuarios.json"))
            {
                Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario("Emanuel", "Diaz", "emanueldiaz0596@gmail.com", "1234", "Administrador");
                nuevoUsuario.usuarios.Add(nuevoUsuario);
                string archivojson = System.Text.Json.JsonSerializer.Serialize(nuevoUsuario.Usuarios);
                json.Write(archivojson);
            }
        }
    }
}
