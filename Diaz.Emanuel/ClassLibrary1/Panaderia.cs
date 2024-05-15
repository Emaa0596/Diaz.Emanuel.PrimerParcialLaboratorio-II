using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas
{
    public class Panaderia : Tienda
    {
        private List<EPanaderia> productos;
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
            return $"La panaderia ubicada en {base.direccion} tiene {base.cantidadDeEmpleados} empleados y vende productos panificados";
        }
    }
}
