using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas
{
    public class Carniceria : Tienda
    {
        internal List<ECarniceria> productos;
        public string descuento;
        public string tipoDeCarne;

        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ECarniceria> productosDisponibles, string tipoDeCarne)
            :base(direccion,cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.descuento = "10%";
            this.tipoDeCarne = tipoDeCarne;
        }

        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ECarniceria> productosDisponibles, string porcentajeDescuento, string tipoDeCarne)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.descuento = porcentajeDescuento;
            this.tipoDeCarne= tipoDeCarne;
        }

        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, string porcentajeDescuento)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = new List<ECarniceria> ();
            this.descuento = porcentajeDescuento;
            this.tipoDeCarne = "Variada";
        }

        protected override string DatosDeLatienda()
        {
            return $"La carniceria ubicada en {base.direccion}, tiene {base.cantidadDeEmpleados} empleados y vende carne {this.tipoDeCarne}";
        }

        public override string ToString()
        {
            string dato = this.DatosDeLatienda();
            dato += $"\nEl descuento actualmente es de {this.descuento} en compras mayores a $20.000";
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
