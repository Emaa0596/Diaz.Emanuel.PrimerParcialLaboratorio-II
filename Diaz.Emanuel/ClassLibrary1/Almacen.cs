using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas
{
    internal class Almacen : Tienda
    {
        private List<EAlmacen> productos;
        public string promociones;

        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, List<EAlmacen> listaProductos, string promociones) 
            :base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaProductos;
            this.promociones = promociones;
        }

        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, List<EAlmacen> listaProductos)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = listaProductos;
            this.promociones = " ";
        }

        public Almacen(string direccion, int cantidadEmpleados, string tipoDeProductos, string promociones)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = new List<EAlmacen>();
            this.promociones = promociones;
        }

        protected override string DatosDeLatienda()
        {
            return $"El almacen ubicada en {base.direccion} tiene {base.cantidadDeEmpleados} empleados y vende productos varios";
        }
    }
}
