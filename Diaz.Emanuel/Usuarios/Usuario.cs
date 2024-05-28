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

        public static bool operator == (Usuario primerUsuario, Usuario segundoUsuario)
        {
            bool retorno = false;
            if(primerUsuario.CorreoElectronico == segundoUsuario.CorreoElectronico && primerUsuario.Clave == segundoUsuario.Clave)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Usuario primerUsuario, Usuario segundoUsuario)
        {
            return !(primerUsuario == segundoUsuario);
        }
        
    }
}
