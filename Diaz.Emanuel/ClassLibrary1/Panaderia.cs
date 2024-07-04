using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Productos;

namespace Tiendas
{
    public class Panaderia : Tienda
    {
        public List<ProductosAlmacen> productos;
        public string formasDePago;

        /// <summary>
        /// Inicializa los atributos con forma de pago solo en efectivo.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="listaDeProductos"></param>
        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen> listaDeProductos)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaDeProductos;
            this.formasDePago = "Efectivo";
        }

        /// <summary>
        /// Inicializa los atributos con forma de pago solo en venta online.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="listaDeProductos"></param>
        public Panaderia(int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen> productosDisponibles, string formasDePago)
            : base(direccion: "Solo venta online", cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.formasDePago = formasDePago;
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="tipoDeProductos"></param>
        /// <param name="listaDeProductos"></param>
        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen>productosDisponibles, string formasDePago)
            :base(direccion,cantidadEmpleados,tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.formasDePago = formasDePago;
        }

        protected override string DatosDeLatienda()
        {
            return $"Panaderia ubicada en {base.direccion}, tiene {base.cantidadDeEmpleados} empleados y vende productos panificados";
        }

        public override string ToString()
        {
            string dato = this.DatosDeLatienda();
            dato += $"\nLa forma de pago actualmente es: {this.formasDePago}";
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
