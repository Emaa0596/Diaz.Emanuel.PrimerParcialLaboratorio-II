using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Productos;

namespace Tiendas
{
    public class Canasta
    {
        public List<ProductosAlmacen> listaAlmacen;
        public List<ProductosCarniceria> listaCarniceria;
        public List<ProductosPanaderia> listaPanaderia;
        private double totalAPagar;

        /// <summary>
        /// Inicializa los atributos
        /// </summary>
        public Canasta()
        {
            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
            this.totalAPagar = 0.0;
        }

        public string CalcularTotalAPagar()
        {
            this.totalAPagar = 0.0;
            if (this.listaAlmacen.Count > 0)
            {
                foreach (ProductosAlmacen prod in this.listaAlmacen)
                {
                    this.totalAPagar += (prod.Precio * prod.Cantidad);
                }
            }
            if (this.listaCarniceria.Count > 0)
            {
                foreach (ProductosCarniceria prod in this.listaCarniceria)
                {
                    this.totalAPagar += (prod.Precio * prod.Cantidad);
                }
            }
            if (this.listaPanaderia.Count > 0)
            {
                foreach (ProductosPanaderia prod in this.listaPanaderia)
                {
                    this.totalAPagar += (prod.Precio * prod.Cantidad);
                }
            }
            string total = "$" + this.totalAPagar.ToString();
            return total;
        }

        /// <summary>
        /// Agrega el producto al carrito o le suma 1 cantidad.
        /// </summary>
        /// <param name="carrito"></param>
        /// <param name="nuevoProducto"></param>
        /// <returns></returns>
        public static Canasta operator + (Canasta carrito, ProductosCarniceria nuevoProducto)
        {
            if (carrito.listaCarniceria.Count > 0)
            {
                bool coincidencia = false;
                foreach (ProductosCarniceria producto in carrito.listaCarniceria)
                {
                    if (producto == nuevoProducto)
                    {
                        producto.Cantidad += 1;
                        coincidencia = true;
                        break;
                    }
                }
                if (!coincidencia)
                {
                    nuevoProducto.Cantidad += 1;
                    carrito.listaCarniceria.Add(nuevoProducto);
                }
            }
            else
            {
                nuevoProducto.Cantidad += 1;
                carrito.listaCarniceria.Add(nuevoProducto);
            }
            return carrito;
        }


        public static Canasta operator +(Canasta carrito, ProductosAlmacen nuevoProducto)
        {
            if (carrito.listaAlmacen.Count > 0)
            {
                bool coincidencia = false;
                foreach (ProductosAlmacen producto in carrito.listaAlmacen)
                {
                    if (producto == nuevoProducto)
                    {
                        producto.Cantidad += 1;
                        coincidencia = true;
                        break;
                    }
                }
                if (!coincidencia)
                {
                    nuevoProducto.Cantidad += 1;
                    carrito.listaAlmacen.Add(nuevoProducto);
                }
            }
            else
            {
                nuevoProducto.Cantidad += 1;
                carrito.listaAlmacen.Add(nuevoProducto);
            }
            return carrito;
        }

        public static Canasta operator +(Canasta carrito, ProductosPanaderia nuevoProducto)
        {
            if (carrito.listaPanaderia.Count > 0)
            {
                bool coincidencia = false;
                foreach (ProductosPanaderia producto in carrito.listaPanaderia)
                {
                    if (producto == nuevoProducto)
                    {
                        producto.Cantidad += 1;
                        coincidencia = true;
                        break;
                    }
                }
                if (!coincidencia)
                {
                    nuevoProducto.Cantidad += 1;
                    carrito.listaPanaderia.Add(nuevoProducto);
                }
            }
            else
            {
                nuevoProducto.Cantidad += 1;
                carrito.listaPanaderia.Add(nuevoProducto);
            }
            return carrito;
        }

        /// <summary>
        /// Elimina un producto del carrito o le quita 1 unidad.
        /// </summary>
        /// <param name="carrito"></param>
        /// <param name="nuevoProducto"></param>
        /// <returns></returns>
        public static Canasta operator -(Canasta carrito, ProductosCarniceria nuevoProducto)
        {
            if (carrito.listaCarniceria.Count > 0)
            {
                foreach (ProductosCarniceria producto in carrito.listaCarniceria)
                {
                    if (producto == nuevoProducto)
                    {
                        if (producto.Cantidad > 1)
                        {
                            producto.Cantidad -= 1;
                        }
                        else
                        {
                            carrito.listaCarniceria.Remove(producto);
                            producto.Cantidad = 0;
                        }
                        break;
                    }
                }
            }
            return carrito;
        }

        public static Canasta operator -(Canasta carrito, ProductosAlmacen nuevoProducto)
        {
            if (carrito.listaAlmacen.Count > 0)
            {
                foreach (ProductosAlmacen producto in carrito.listaAlmacen)
                {
                    if (producto == nuevoProducto)
                    {
                        if (producto.Cantidad > 1)
                        {
                            producto.Cantidad -= 1;
                        }
                        else
                        {
                            carrito.listaAlmacen.Remove(producto);
                            producto.Cantidad = 0;
                        }
                        break;
                    }
                }
            }
            return carrito;
        }

        public static Canasta operator -(Canasta carrito, ProductosPanaderia nuevoProducto)
        {
            if (carrito.listaPanaderia.Count > 0)
            {
                foreach (ProductosPanaderia producto in carrito.listaPanaderia)
                {
                    if (producto == nuevoProducto)
                    {
                        if (producto.Cantidad > 1)
                        {
                            producto.Cantidad -= 1;
                        }
                        else
                        {
                            carrito.listaPanaderia.Remove(producto);
                            producto.Cantidad = 0;
                        }
                        break;
                    }
                }
            }
            return carrito;
        }

    }
}
