using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosAlmacen : Producto, IConversionProductos<ProductosAlmacen>
    {
        /// <summary>
        /// Inicializa con valores minimos los atributos en la clase padre.
        /// </summary>
        public ProductosAlmacen() :base(0,"",0,0)
        {
            
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public ProductosAlmacen(int codigo, string nombre, double precio,int cantidad) : base(codigo, nombre, precio, cantidad) 
        {
            
        }

        public new int Codigo
        {
            get { return base.Codigo; }
            set { base.Codigo = value; }
        }

        public new string? Nombre
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

        /// <summary>
        /// Muestra los datos del producto. Se aplica polimorfismo. 
        /// </summary>
        /// <returns>String con descripcion del producto. </returns>
        public override string Mostrar()
        {
            return $"Producto de almacen, su precio es ${this.precio} xUnidad, cantidad maxima de unidades: 5";
        }

        /// <summary>
        /// Convierte el producto pasado por parametro a producto almacen. Se implementa la interfaz.
        /// </summary>
        /// <param name="producto">Producto</param>
        /// <returns>Producto casteado a almacen.</returns>
        public ProductosAlmacen ConvertirProductos(Producto producto)
        {
            ProductosAlmacen productoConvertido = new ProductosAlmacen(producto.Codigo, producto.Nombre, producto.Precio, producto.Cantidad);
            return productoConvertido;
        }
    }
}
