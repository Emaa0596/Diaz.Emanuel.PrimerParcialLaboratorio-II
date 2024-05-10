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
        }

        public FormLogin(List<Usuario> usuarios)
        {
            InitializeComponent();
            this.usuarios = usuarios;
        }

        public List<Usuario> Usuarios { get { return this.usuarios; } }

        private void botonIngresar_Click(object sender, EventArgs e)
        {

            string correoElectronico = this.textBoxUsuario.Text;
            string contraseña = this.textBoxContraseña.Text;
            Usuarios.Usuario nuevoUsuario = new Usuarios.Usuario(correoElectronico, contraseña);
            //List<Usuario> listaDeUsuarios = DeserializarJson();
            bool buscadorUsuarios = BuscarUsuarios(this.usuarios, nuevoUsuario);
            if (buscadorUsuarios)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario no existe o la clave es incorrecta", "Usuario no encontrado", MessageBoxButtons.OK);
            }
        }

        private bool BuscarUsuarios(List<Usuario> listaUsuarios, Usuario nuevoUsuario)
        {
            bool coincidencia = false;
            foreach (Usuario usuarioGuardado in listaUsuarios)
            {
                if (usuarioGuardado.correoElectronico == nuevoUsuario.correoElectronico && usuarioGuardado.clave == nuevoUsuario.clave)
                {
                    coincidencia = true;
                }
            }
            return coincidencia;
        }

        private List<Usuario> DeserializarJson()
        {
            List<Usuario> lista = new List<Usuario>();
            using(StreamReader json = new StreamReader(@"C:\\Users\\NoxiePC\\Desktop\\Archivos\\Usuarios.json"))
            {
                string strJson = json.ReadToEnd();
                List<Usuario> listaJson = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(strJson);
                foreach (Usuario usuarios in listaJson)
                {
                    lista.Add(usuarios);
                }
            }
            return lista;
        }

        private void linkCrearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCrearUsuario nuevoUsuario = new FormCrearUsuario(this.usuarios);
            nuevoUsuario.ShowDialog();
        }
    }
}
