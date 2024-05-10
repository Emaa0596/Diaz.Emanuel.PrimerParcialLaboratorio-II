using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios
{
    public static class Datos
    {
        private static List<Usuario> listaUsuarios;

        static Datos()
        {
            listaUsuarios = new List<Usuario>();
        }

        public static List<Usuario> ListaUsuarios
        {
            get { return listaUsuarios; }
        }
        public static Usuario CrearUsuario()
        {
            
            Usuario nuevoUsuario = new Usuario("Emanuel", "Diaz", "emanueldiaz0596@gmail.com", "1234", "administrador");
            //nuevoUsuario.AgregarUsuario();
            
            listaUsuarios.Add(nuevoUsuario);
            return nuevoUsuario;
        }

        public static void SerializarDatos(Usuario user)
        {
            using (StreamWriter json = new StreamWriter("C:\\Users\\NoxiePC\\Desktop\\Archivos\\Usuarios.json"))
            {
                string archivoJson = System.Text.Json.JsonSerializer.Serialize(Datos.ListaUsuarios);

                foreach(Usuario usuario in ListaUsuarios)
                {
                    string archivo = System.Text.Json.JsonSerializer.Serialize(usuario);
                    json.WriteLine(archivo);
                }

                //json.WriteLine(archivoJson);
            }
        }

        public static List<Usuario> DeserializarDatos()
        {   
            List<Usuario> lista = new List<Usuario>();
            using (StreamReader json = new StreamReader("C:\\Users\\NoxiePC\\Desktop\\Archivos\\Usuarios.json"))
            {
                string strjson = json.ReadToEnd();
                List<Usuario> listajson = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(strjson);
                foreach (Usuario user in listajson)
                {
                    lista.Add(user);
                }
            }
            return lista;
        }

        public static bool BuscarUsuarios(Usuario usuario, List<Usuario> lista)
        {
            bool coincidencia = false;
            foreach (Usuario usuarioGuardado in lista)
            {
                if(usuarioGuardado.correoElectronico == usuario.correoElectronico)
                {
                    coincidencia = true;
                }
            }
            return coincidencia;
        }

        public static void AgregarUsuario(Usuario usuario)
        {
            Datos.listaUsuarios.Add(usuario);
        }
    }
}
