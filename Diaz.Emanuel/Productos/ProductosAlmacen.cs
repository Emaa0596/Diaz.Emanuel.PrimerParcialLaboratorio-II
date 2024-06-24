using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosAlmacen : Producto, IConversionProductos<ProductosAlmacen>
    {
        public ProductosAlmacen() :base(0,"",0,0)
        {
            
        }

        public ProductosAlmacen(int codigo, string nombre, double precio,int cantidad) : base(codigo, nombre, precio, cantidad) 
        {
            
        }

        public new int Codigo
        {
            get { return base.Codigo; }
            set { base.Codigo = value; }
        }

        public new string Nombre
        {
            get { return base.Nombre; }
            set { base.Nombre = value; }
        }

        public new double Precio
        {
            get { return base.Precio; }
            set { base.Precio = value; }
        }

        public new int Cantidad
        {
            get { return base.Cantidad; }
            set { base.Cantidad = value; }
        }

        public ProductosAlmacen ConvertirProductos(Producto producto)
        {
            ProductosAlmacen productoConvertido = new ProductosAlmacen(producto.Codigo, producto.Nombre, producto.Precio, producto.Cantidad);
            return productoConvertido;
        }
    }
}
