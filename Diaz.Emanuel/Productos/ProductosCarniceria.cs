using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosCarniceria : Producto
    {
        public float peso;
        public double precioFinalPesado;

        public ProductosCarniceria(int codigo, string nombre, double precioPorKilo, float peso) :base(codigo, nombre, precioPorKilo)
        {
            this.peso = peso;
            this.precioFinalPesado = base.Precio * this.peso;
        }


    }

}
