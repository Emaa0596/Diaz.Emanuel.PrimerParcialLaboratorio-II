using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas
{
    internal class Carniceria : Tienda
    {
        private List<ECarniceria> productos;
        public string descuento;

        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ECarniceria> productosDisponibles)
            :base(direccion,cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.descuento = "10%";
        }

        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, List<ECarniceria> productosDisponibles, string porcentajeDescuento)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.descuento = porcentajeDescuento;
        }

        public Carniceria(string direccion, int cantidadEmpleados, string tipoDeProductos, string porcentajeDescuento)
            : base(direccion, cantidadEmpleados, tipoDeProductos)
        {
            this.productos = new List<ECarniceria> ();
            this.descuento = porcentajeDescuento;
        }

        protected override string DatosDeLatienda()
        {
            return $"La carniceria ubicada en {base.direccion} tiene {base.cantidadDeEmpleados} empleados y vende carne vacuna";
        }

    }
}
