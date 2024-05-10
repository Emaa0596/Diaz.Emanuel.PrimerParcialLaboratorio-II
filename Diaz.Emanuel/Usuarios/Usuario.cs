using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Usuarios
{
    public class Usuario
    {
        public string nombre;
        public string apellido;
        public string correoElectronico;
        public string clave;
        public string perfil;


        public string Nombre 
        { 
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set {  apellido = value; }
        }

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        public string Clave 
        { 
            get { return clave; } 
            set {  clave = value; }
        }

        public string Perfil
        { 
            get { return perfil; } 
            set {  perfil = value; }
        }



        public Usuario()
        {

        }

        public Usuario(string nombre, string apellido, string correoElectronico, string contraseña, string perfil)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.correoElectronico = correoElectronico;
            this.clave = contraseña;
            this.perfil = perfil;
        }

        public Usuario(string correoElectronico,string contraseña)
        {
            this.correoElectronico=correoElectronico;
            this.clave = contraseña;
        }





        //public List<Usuario> Usuarios
        //{
        //    get { return usuarios; }
        //}


        //public bool BuscarUsuarios()
        //{
        //    bool retorno = false;
        //    if (this.usuarios.Count > 0 && this.usuarios != null)
        //    {
        //        foreach (Usuario usuario in this.usuarios)
        //        {
        //            if (this.correoElectronico == usuario.correoElectronico)
        //            {
        //                retorno = true;
        //            }
        //        }
        //    }
        //    return retorno;
        //}

        //public void ObtenerListaUsuarios()
        //{
        //    if (this.usuarios == null)
        //    {
        //        string rutaArchivo = @".\\Usuarios.json";

        //        if (File.Exists(rutaArchivo))
        //        {
        //            using (StreamReader json = new StreamReader(rutaArchivo))
        //            {
        //                string strJson = json.ReadToEnd();
        //                this.usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(strJson);
        //            }
        //        }
        //        else
        //        {
        //            Usuario nuevoUsuario = new Usuario("Emanuel", "Diaz", "emanueldiaz0596@gmail.com", "1234", "Administrador");
        //            this.usuarios = new List<Usuario>() { nuevoUsuario };
        //            SerializarUsuarios(this.usuarios);
        //        }
        //    }

        //}

        //public void AgregarUsuario()
        //{

        //    this.usuarios.Add(this);
        //}

        public void SerializarUsuarios(List<Usuario> listaUsuarios)
        {
            string rutaArchivo = @".\\Usuarios.json";
            string strJson = System.Text.Json.JsonSerializer.Serialize(listaUsuarios);
            File.WriteAllText(rutaArchivo, strJson);
        }

    }
}
