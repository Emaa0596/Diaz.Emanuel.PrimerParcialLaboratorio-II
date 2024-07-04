using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Productos;

namespace Tiendas
{
    public class Carniceria : Tienda
    {
        internal List<ProductosCarniceria> productos;
        public string descuento;
        public string tipoDeCarne;

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro, y un descuento del 10%.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="productosDisponibles"></param>
        /// <param name="tipoDeCarne"></param>
        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosCarniceria> productosDisponibles, string tipoDeCarne)
            :base(direccion,cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.descuento = "10%";
            this.tipoDeCarne = tipoDeCarne;
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="productosDisponibles"></param>
        /// <param name="tipoDeCarne"></param>
        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosCarniceria> productosDisponibles, string porcentajeDescuento, string tipoDeCarne)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.descuento = porcentajeDescuento;
            this.tipoDeCarne= tipoDeCarne;
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro, y tipo de carne variada.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="productosDisponibles"></param>
        /// <param name="tipoDeCarne"></param>
        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, string porcentajeDescuento)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = new List<ProductosCarniceria> ();
            this.descuento = porcentajeDescuento;
            this.tipoDeCarne = "Variada";
        }

        protected override string DatosDeLatienda()
        {
            return $"Carniceria ubicada en {base.direccion}, tiene {base.cantidadDeEmpleados} empleados y vende carne {this.tipoDeCarne}";
        }

        public override string ToString()
        {
            string dato = this.DatosDeLatienda();
            if(this.descuento != "0")
            {
                dato += $"\nEl descuento actualmente es de {this.descuento} en compras mayores a $20.000";
            }
            return dato;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (base.Equals(obj) == true)
            {
                Carniceria nuevaCarniceria = (Carniceria)obj;
                if (nuevaCarniceria.tipoDeCarne == this.tipoDeCarne)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator == (Carniceria carniceria, Carniceria otraCarniceria)
        {
            bool retorno = false;
            if (carniceria.Equals(otraCarniceria))
            {
                if(carniceria.direccion == otraCarniceria.direccion && carniceria.tipoDeCarne == otraCarniceria.tipoDeCarne)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator != (Carniceria carniceria, Carniceria otraCarniceria)
        {
            return !(carniceria == otraCarniceria);
        }

    }
}
