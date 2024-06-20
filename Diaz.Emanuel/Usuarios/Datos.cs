using Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Usuarios
{
    public static class Datos
    {
        private static List<Usuario> listaUsuarios;
        public static Database basesql;

        static Datos()
        {
            listaUsuarios = new List<Usuario>();
            basesql = new Database();
        }

        public static List<Usuario> ListaUsuarios
        {
            get { return listaUsuarios; }
        }

        /// <summary>
        /// Agrega el nuevo usuario al archivo de usuarios y lo vuelve a serializar
        /// </summary>
        /// <param name="user"></param>
        public static void SerializarDatos(Usuario user)
        {
            List<Usuario> listaDeUsuarios = DeserializarDatos();
            listaDeUsuarios.Add(user);
            JsonSerializerOptions formatoDeSerializado = new JsonSerializerOptions();
            formatoDeSerializado.WriteIndented = true;
            using (StreamWriter json = new StreamWriter(@".\Usuarios.json"))
            {
                string archivoJson = System.Text.Json.JsonSerializer.Serialize(listaDeUsuarios,formatoDeSerializado);
                json.WriteLine(archivoJson);
                
            }
        }

        /// <summary>
        /// Castea los productos al tipo correspondiente
        /// </summary>
        /// <param name="listaProductos"></param>
        /// <returns>La lista de productos casteada</returns>
        public static List<ProductosCarniceria> ConvertirProductosCarniceria(List<Producto> listaProductos)
        {
            List<ProductosCarniceria> lista = new List<ProductosCarniceria>();
            foreach(Producto prod in listaProductos)
            {
                ProductosCarniceria producto = new ProductosCarniceria(prod.Codigo,prod.Nombre,prod.Precio,prod.Cantidad,1);
                lista.Add(producto);
            }
            return lista;
        }

        public static List<ProductosAlmacen> ConvertirProductosAlmacen(List<Producto> listaProductos)
        {
            List<ProductosAlmacen> lista = new List<ProductosAlmacen>();
            foreach (Producto prod in listaProductos)
            {
                ProductosAlmacen producto = new ProductosAlmacen(prod.Codigo,prod.Nombre,prod.Precio,prod.Cantidad);
                lista.Add(producto);
            }
            return lista;
        }

        public static List<ProductosPanaderia> ConvertirProductosPanaderia(List<Producto> listaProductos)
        {
            List<ProductosPanaderia> lista = new List<ProductosPanaderia>();
            foreach (Producto prod in listaProductos)
            {
                //ProductosPanaderia producto = (ProductosPanaderia)prod;
                ProductosPanaderia producto = new ProductosPanaderia(prod.Codigo, prod.Nombre, prod.Precio, prod.Cantidad,1);
                lista.Add(producto);
            }
            return lista;
        }

        /// <summary>
        /// Serializa los productos correspondientes y los guarda en la ruta especificada. 
        /// </summary>
        /// <param name="listaProductos"></param>
        /// <param name="ruta"></param>
        public static void SerializarDatos(List<ProductosAlmacen> listaProductos, string ruta)
        {
            JsonSerializerOptions formatoDeSerializado = new JsonSerializerOptions();
            formatoDeSerializado.WriteIndented = true;

            using (StreamWriter json = new StreamWriter(@$"{ruta}"))
            {
                string archivoJson = System.Text.Json.JsonSerializer.Serialize(listaProductos, formatoDeSerializado);
                json.WriteLine(archivoJson);
            }
        }

        public static void SerializarDatos(List<ProductosCarniceria> listaProductos, string ruta)
        {
            JsonSerializerOptions formatoDeSerializado = new JsonSerializerOptions();
            formatoDeSerializado.WriteIndented = true;

            using (StreamWriter json = new StreamWriter(@$"{ruta}"))
            {
                string archivoJson = System.Text.Json.JsonSerializer.Serialize(listaProductos, formatoDeSerializado);
                json.WriteLine(archivoJson);
            }
        }

        public static void SerializarDatos(List<ProductosPanaderia> listaProductos, string ruta)
        {
            JsonSerializerOptions formatoDeSerializado = new JsonSerializerOptions();
            formatoDeSerializado.WriteIndented = true;

            using (StreamWriter json = new StreamWriter(@$"{ruta}"))
            {
                string archivoJson = System.Text.Json.JsonSerializer.Serialize(listaProductos, formatoDeSerializado);
                json.WriteLine(archivoJson);
            }
        }


        public static List<Usuario> DeserializarDatos()
        {   
            List<Usuario> lista = new List<Usuario>();
            using (StreamReader json = new StreamReader(@".\Usuarios.json"))
            {
                string strjson = json.ReadToEnd();
                List<Usuario>? listajson = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(strjson);
                if(listajson != null)
                {
                    foreach (Usuario user in listajson)
                    {
                        lista.Add(user);
                    }
                }
            }
            return lista;
        }

        public static List<Producto> DeserializarProductos(string ruta)
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                using (StreamReader json = new StreamReader(@$"{ruta}"))
                {
                    string strjson = json.ReadToEnd();
                    List<Producto>? listajson = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(strjson);
                    if (listajson != null)
                    {
                        foreach (Producto prod in listajson)
                        {
                            lista.Add(prod);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                List<Producto> listaVacia = new List<Producto>();
                return listaVacia;
            }

            return lista;
        }

        /// <summary>
        /// Crea un string con los datos y tiempo en el que un usuario ingreso.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private static string ObtenerDatosIngreso(Usuario usuario)
        {
            DateTime hoy = DateTime.Today;
            string formatoDia = hoy.ToString("yyyy-MM-dd");
            DateTime horaActual = DateTime.Now;
            string formatoHora = $"{horaActual.Hour}:{horaActual.Minute}:{horaActual.Second}";
            StringBuilder texto = new StringBuilder();
            string datosUsuario = $"Nombre: {usuario.Nombre} Apellido: {usuario.Apellido} Correo Electronico: {usuario.CorreoElectronico} Perfil: {usuario.Perfil} ";
            texto.Append(datosUsuario);
            texto.Append("Fecha de ingreso: " + formatoDia + " Hora: " + formatoHora);
            return texto.ToString();
        }

        /// <summary>
        /// Guarda en un archivo.log los datos del usuario
        /// </summary>
        /// <param name="usuario"></param>
        private static void GuardarDatos(Usuario usuario)
        {
            string datosLogueo = ObtenerDatosIngreso(usuario);
            using (StreamWriter sw = new StreamWriter(@".\usuariosLogueo.log",true))
            {
                sw.WriteLine(datosLogueo);
            }
        }

        public static bool BuscarUsuarios(Usuario usuario)
        {
            List<Usuario> listaDeUsuarios = DeserializarDatos();
            bool coincidencia = false;
            foreach (Usuario usuarioGuardado in listaDeUsuarios)
            {
                if(usuarioGuardado == usuario)
                {
                    Datos.GuardarDatos(usuarioGuardado);
                    coincidencia = true;
                    break;
                }
            }
            return coincidencia;
        }

        public static void AgregarUsuario(Usuario usuario)
        {
            Datos.SerializarDatos(usuario);
        }
    }
}
