using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas
{
    public class Panaderia : Tienda
    {
        internal List<EPanaderia> productos;
        string formasDePago;

        /*
        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos)
            :base(direccion,cantidadEmpleados,tipoDeProductos)
        {
            this.productos = new List<EPanaderia>();
            this.formasDePago = "Efectivo";
        }
        */

        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos, List<EPanaderia> listaDeProductos)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaDeProductos;
            this.formasDePago = "Efectivo";
        }

        public Panaderia(int cantidadEmpleados, string tipoDeProductos, List<EPanaderia> productosDisponibles, string formasDePago)
            : base(direccion: "Solo venta online", cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.formasDePago = formasDePago;
        }

        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos, List<EPanaderia>productosDisponibles, string formasDePago)
            :base(direccion,cantidadEmpleados,tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.formasDePago = formasDePago;
        }

        protected override string DatosDeLatienda()
        {
            return $"La panaderia ubicada en {base.direccion}, tiene {base.cantidadDeEmpleados} empleados y vende productos panificados";
        }

        public override string ToString()
        {
            string dato = this.DatosDeLatienda();
            dato += $"\nLa/s forma de pago actualmente son: {this.formasDePago}";
            return dato;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (base.Equals(obj) == true)
            {
                Panaderia nuevaPanaderia = (Panaderia)obj;
                if(nuevaPanaderia.formasDePago == this.formasDePago)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator == (Panaderia panaderia, Panaderia otraPanaderia)
        {
            bool retorno = false;
            if (panaderia.Equals(otraPanaderia))
            {
                if (panaderia.direccion == otraPanaderia.direccion && panaderia.productos.Count == otraPanaderia.productos.Count)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Panaderia panaderia, Panaderia otraPanaderia)
        {
            return !(panaderia == otraPanaderia);
        }

        public static implicit operator Almacen(Panaderia panaderia)
        {
            Almacen nuevoAlmacen = new Almacen(panaderia.direccion, panaderia.cantidadDeEmpleados, "Articulos varios", "Ninguna");
            return nuevoAlmacen;
        }

    }
}
