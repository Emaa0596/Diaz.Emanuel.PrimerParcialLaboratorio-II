using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosAlmacen : Producto
    {
        public ProductosAlmacen(int codigo, string nombre, double precio) : base(codigo, nombre, precio) 
        {
            
        }
    }
}
