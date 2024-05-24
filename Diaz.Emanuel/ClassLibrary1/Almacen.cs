﻿using System;
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

        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen> listaProductos, string promociones) 
            :base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaProductos;
            this.promociones = promociones;
        }

        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ProductosAlmacen> listaProductos)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaProductos;
            this.promociones = "";
        }

        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, string promociones)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = new List<ProductosAlmacen>();
            this.promociones = promociones;
        }

        protected override string DatosDeLatienda()
        {
            return $"El almacen ubicada en {base.direccion}, tiene {base.cantidadDeEmpleados} empleados y vende articulos varios";
        }

        public override string ToString()
        {
            string dato = this.DatosDeLatienda();
            dato += $"\nLa promocion del dia es {this.promociones}";
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
