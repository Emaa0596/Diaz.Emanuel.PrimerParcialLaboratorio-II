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

        static Datos()
        {
            listaUsuarios = new List<Usuario>();
        }

        public static List<Usuario> ListaUsuarios
        {
            get { return listaUsuarios; }
        }

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

        public static List<Usuario> DeserializarDatos()
        {   
            List<Usuario> lista = new List<Usuario>();
            using (StreamReader json = new StreamReader(@".\Usuarios.json"))
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

        public static bool BuscarUsuarios(Usuario usuario)
        {
            List<Usuario> listaDeUsuarios = DeserializarDatos();
            bool coincidencia = false;
            foreach (Usuario usuarioGuardado in listaDeUsuarios)
            {
                if(usuarioGuardado.correoElectronico == usuario.correoElectronico && usuarioGuardado.clave == usuario.clave)
                {
                    coincidencia = true;
                }
            }
            return coincidencia;
        }

        public static void AgregarUsuario(Usuario usuario)
        {
            Datos.SerializarDatos(usuario);
        }

        public static List<Productos.Producto> OrdenarPorCriterio(List<Productos.Producto> lista, EOrdenamiento criterio)
        {
            if (criterio == EOrdenamiento.MayorAMenorCantidad)
            {
                int largoDeLista = lista.Count;
                for (int i = 0; i < largoDeLista - 1; i++)
                {
                    for (int j = i + 1; j < largoDeLista; j++)
                    {
                        if (lista[i].Cantidad < lista[j].Cantidad)
                        {
                            Producto aux = lista[i];
                            lista[i] = lista[j];
                            lista[j] = aux;
                        }
                    }
                }
            }
            else if (criterio == EOrdenamiento.MenorAMayorCantidad)
            {
                int largoDeLista = lista.Count;
                for (int i = 0; i < largoDeLista - 1; i++)
                {
                    for (int j = i + 1; j < largoDeLista; j++)
                    {
                        if (lista[i].Cantidad > lista[j].Cantidad)
                        {
                            Producto aux = lista[i];
                            lista[i] = lista[j];
                            lista[j] = aux;
                        }
                    }
                }
            }
            else if (criterio == EOrdenamiento.MenorAMayorPrecio)
            {
                int largoDeLista = lista.Count;
                for (int i = 0; i < largoDeLista - 1; i++)
                {
                    for (int j = i + 1; j < largoDeLista; j++)
                    {
                        if (lista[i].Precio > lista[j].Precio)
                        {
                            Producto aux = lista[i];
                            lista[i] = lista[j];
                            lista[j] = aux;
                        }
                    }
                }
            }
            else 
            {
                int largoDeLista = lista.Count;
                for (int i = 0; i < largoDeLista - 1; i++)
                {
                    for (int j = i + 1; j < largoDeLista; j++)
                    {
                        if (lista[i].Precio < lista[j].Precio)
                        {
                            Producto aux = lista[i];
                            lista[i] = lista[j];
                            lista[j] = aux;
                        }
                    }
                }
            }
            return lista;
            
        }
    }
}
