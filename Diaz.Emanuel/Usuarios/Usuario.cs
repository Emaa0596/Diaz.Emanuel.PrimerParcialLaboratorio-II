using System.Runtime.CompilerServices;

namespace Usuarios
{
    public class Usuario
    {
        public string nombre;
        public string apellido;
        public string correoElectronico;
        public string contraseña;
        public string perfil;
        public string legajo;

        public List<Usuario> usuarios;
        

        public Usuario(string nombre, string apellido, string correoElectronico, string contraseña, string perfil)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correoElectronico = correoElectronico;
            this.contraseña = contraseña;
            this.perfil = perfil;
            //this.ObtenerListaUsuarios();
            //this.usuarios = ObtenerListaUsuarios();
        }

        public Usuario(string correoElectronico,string contraseña)
        {
            this.correoElectronico=correoElectronico;
            this.contraseña = contraseña;
            //this.ObtenerListaUsuarios();
        }

        public List<Usuario> Usuarios
        {
            get { return usuarios; }
        }

        public List<Usuario> ListaUsuarios
        {
            get { return usuarios; }
        }

        public bool BuscarUsuarios()
        {
            bool retorno = false;
            if (this.usuarios.Count > 0 && this.usuarios != null)
            {
                foreach (Usuario usuario in this.usuarios)
                {
                    if (this.correoElectronico == usuario.correoElectronico)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        public void ObtenerListaUsuarios()
        {
            if (this.usuarios == null)
            {
                string rutaArchivo = @".\\Usuarios.json";

                if (File.Exists(rutaArchivo))
                {
                    using (StreamReader json = new StreamReader(rutaArchivo))
                    {
                        string strJson = json.ReadToEnd();
                        this.usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(strJson);
                    }
                }
                else
                {
                    Usuario nuevoUsuario = new Usuario("Emanuel", "Diaz", "emanueldiaz0596@gmail.com", "1234", "Administrador");
                    this.usuarios = new List<Usuario>() { nuevoUsuario };
                    SerializarUsuarios(this.usuarios);
                }
            }

        }

        private void SerializarUsuarios(List<Usuario> listaUsuarios)
        {
            string rutaArchivo = @".\\Usuarios.json";
            string strJson = System.Text.Json.JsonSerializer.Serialize(listaUsuarios);
            File.WriteAllText(rutaArchivo, strJson);
        }

    }
}
