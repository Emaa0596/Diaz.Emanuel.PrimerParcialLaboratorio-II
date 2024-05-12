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
        int cantidadDeHornos;

        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos)
            :base(direccion,cantidadEmpleados,tipoDeProductos)
        {
            this.productos = new List<EPanaderia>();    

        }

        public Panaderia(int cantidadEmpleados, string tipoDeProductos, List<EPanaderia> productosDisponibles, int cantidadHornos)
            : base("Solo venta online", cantidadEmpleados, tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.cantidadDeHornos = cantidadHornos;
        }

        public Panaderia(string direccion, int cantidadEmpleados, string tipoDeProductos,List<EPanaderia>productosDisponibles, int cantidadHornos)
            :base(direccion,cantidadEmpleados,tipoDeProductos)
        {
            this.productos = productosDisponibles;
            this.cantidadDeHornos = cantidadHornos;
        }

        
    }
}
