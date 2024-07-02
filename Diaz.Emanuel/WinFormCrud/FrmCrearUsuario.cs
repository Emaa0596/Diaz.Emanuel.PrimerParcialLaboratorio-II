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
    public partial class FrmCrearUsuario : Form
    {
        List<Usuario> usuarios;
        public FrmCrearUsuario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.usuarios = new List<Usuario>();
        }

        public string Nombre
        {
            get { return textBoxNombre.Text; }
            set { textBoxNombre.Text = value; }
        }

        public string Apellido
        {
            get { return textBoxApellido.Text; }
            set { textBoxApellido.Text = value; }
        }

        public string CorreoElectronico
        {
            get { return textBoxCorreoElectronico.Text; }
            set { textBoxCorreoElectronico.Text = value; }
        }

        public string Contraseña
        {
            get { return textBoxContraseña.Text; }
            set { textBoxContraseña.Text = value; }
        }

        public string Perfil
        {
            get { return comboBoxPerfil.Text; }
            set { comboBoxPerfil.Text = value; }
        }

        public void FormCrearUsuario_Load(object sender, EventArgs e)
        {
            this.usuarios = Datos.DeserializarDatos();
            this.comboBoxPerfil.SelectedIndex = 0;
        }

        public void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            bool buscador = false;
            string nombre = this.textBoxNombre.Text;
            string apellido = this.textBoxApellido.Text;
            string email = this.textBoxCorreoElectronico.Text;
            string contraseña = this.textBoxContraseña.Text;
            string perfil = this.comboBoxPerfil.Text;
            bool validador = false;
            if (perfil != "Vendedor")
            {
                FrmValidacionPerfil validacion = new FrmValidacionPerfil(perfil);
                validacion.ShowDialog();
                if (validacion.DialogResult == DialogResult.OK) { validador = true; }
            }
            else
            {
                validador = true;
            }

            if (validador && this.ValidateChildren())
            {
                Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario(nombre, apellido, email, contraseña, perfil);
                buscador = Datos.BuscarUsuarios(nuevoUsuario);
                if (buscador)
                {
                    MessageBox.Show("Ya existe un usuario con el mismo correo electronico", "Error", MessageBoxButtons.OK);
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    Datos.AgregarUsuario(nuevoUsuario);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
            }
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    e.Cancel = true;
                    textBox.Focus();
                    errorProvider1.SetError(textBox, "Este campo es obligatorio y no puede contener solo espacios en blanco.");
                }
                else
                {
                    if(textBox.Name == "textBoxCorreoElectronico" && !textBox.Text.Contains("@"))
                    {
                        e.Cancel = true;
                        textBox.Focus();
                        errorProvider1.SetError(textBox, "Este campo debe tener un correo electronico valido.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(textBox, "");
                    } 
                }
            }
        }
    }
}
