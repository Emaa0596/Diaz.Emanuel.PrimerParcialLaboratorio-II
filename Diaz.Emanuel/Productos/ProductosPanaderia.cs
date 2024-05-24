using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosPanaderia :ProductosCarniceria
    {
        public ProductosPanaderia(int codigo, string nombre, double precioPorKilo, float peso) : base(codigo, nombre, precioPorKilo, peso)
        {
            this.precioFinalPesado = base.precioFinalPesado;
        }
    }
}
