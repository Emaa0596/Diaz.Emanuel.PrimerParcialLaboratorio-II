using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Productos;

namespace Tiendas
{
    public class Canasta
    {
        private List<ProductosAlmacen> listaAlmacen;
        private List<ProductosCarniceria> listaCarniceria;
        private List<ProductosPanaderia> listaPanaderia;
        private double totalAPagar;

        public Canasta()
        {
            this.listaAlmacen = new List<ProductosAlmacen>();
            this.listaCarniceria = new List<ProductosCarniceria>();
            this.listaPanaderia = new List<ProductosPanaderia>();
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

        public void CalcularTotal()
        {
            if (this.listaAlmacen.Count > 0)
            {
                foreach (ProductosAlmacen prod in this.listaAlmacen)
                {
                    this.totalAPagar += prod.Precio;
                }
            }
            if (this.listaCarniceria.Count > 0)
            {
                foreach (ProductosCarniceria prod in this.listaCarniceria)
                {
                    this.totalAPagar += prod.Precio;
                }
            }
            if (this.listaPanaderia.Count > 0)
            {
                foreach (ProductosPanaderia prod in this.listaPanaderia)
                {
                    this.totalAPagar += prod.Precio;
                }
            }
        }
        
    }
}
