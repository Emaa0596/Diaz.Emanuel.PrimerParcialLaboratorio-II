using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Productos;

namespace Tiendas
{
    public class Almacen : Tienda
    {
        internal List<ProductosAlmacen> productos;
        public string promociones;

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="listaProductos"></param>
        /// <param name="promociones"></param>
        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen> listaProductos, string promociones) 
            :base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaProductos;
            this.promociones = promociones;
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro, sin promociones.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="listaProductos"></param>
        /// <param name="promociones"></param>
        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen> listaProductos)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaProductos;
            this.promociones = "";
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro, con una lista de productos vacia.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="listaProductos"></param>
        /// <param name="promociones"></param>
        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, string promociones)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = new List<ProductosAlmacen>();
            this.promociones = promociones;
        }


        protected override string DatosDeLatienda()
        {
            return $"Almacen ubicado en {base.direccion}, tiene {base.cantidadDeEmpleados} empleados y vende articulos varios";
        }

        public override string ToString()
        {
            string dato = this.DatosDeLatienda();
            if(this.promociones != "")
            {
                dato += $"\nLa promocion del dia es {this.promociones}";
            }
            return dato;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (base.Equals(obj) == true)
            {
                Almacen nuevoAlmacen = (Almacen)obj;
                if (nuevoAlmacen.promociones == this.promociones)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator == (Almacen almacen, Almacen otroAlmacen)
        {
            bool retorno = false;
            if (almacen.Equals(otroAlmacen))
            {
                if(almacen.promociones == otroAlmacen.promociones)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Almacen almacen, Almacen otroAlmacen)
        {
            return !(almacen == otroAlmacen);
        }
    }
}
