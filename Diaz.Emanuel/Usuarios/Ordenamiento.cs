using Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios
{
    public static class Ordenamiento
    {
        /// <summary>
        /// Ordena segun el critero pasado por parametro
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="criterio"></param>
        /// <returns> retorna la lista ordenada </returns>
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
