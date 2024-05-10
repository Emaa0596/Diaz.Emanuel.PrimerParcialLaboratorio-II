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
            this.usuarios = new List<Usuario>();
        }


        public List<Usuario> ListaUsuarios
        {
            get { return this.usuarios; }
            set { this.usuarios = value; }
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            //Usuario nuevoUsuario = new Usuario("Emanuel", "Diaz", "emanueldiaz0596@gmail.com", "1234", "Administrador");
            //this.usuarios.Add(nuevoUsuario);
            //SerializarDatos();
            this.usuarios = Datos.DeserializarDatos();
            FormLogin UsuarioLogueado = new FormLogin(this.usuarios);
            UsuarioLogueado.ShowDialog();
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

        private void SerializarDatos()
        {
            using(StreamWriter json = new StreamWriter(@"C:\\Users\\NoxiePC\\Desktop\\Archivos\\Usuarios.json"))
            {
                string archivo = System.Text.Json.JsonSerializer.Serialize(this.usuarios);
                json.WriteLine(archivo);
            }
        }

        private List<Usuario> DeserializarJson()
        {
            List<Usuario> lista = new List<Usuario>();
            using (StreamReader json = new StreamReader(@"C:\\Users\\NoxiePC\\Desktop\\Archivos\\Usuarios.json"))
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


    }
}
