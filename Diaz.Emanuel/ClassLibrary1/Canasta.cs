using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tiendas
{
    internal class Canasta
    {
        private List<EAlmacen> listaAlmacen;
        private List<ECarniceria> listaCarniceria;
        private List<EPanaderia> listaPanaderia;
        private double totalAPagar;

        public Canasta()
        {
            this.listaAlmacen = new List<EAlmacen>();
            this.listaCarniceria = new List<ECarniceria>();
            this.listaPanaderia = new List<EPanaderia>();
            this.totalAPagar = 0.0;
        }

        public void AgregarProducto(Almacen almacen)
        {
            this.listaAlmacen = almacen.productos;
        }

        public void AgregarProducto(Carniceria carniceria)
        {
            this.listaCarniceria = carniceria.productos;
        }

        public void AgregarProducto(Panaderia panaderia)
        {
            this.listaPanaderia = panaderia.productos;
        }

        
    }
}
