using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosPanaderia :ProductosCarniceria, IConversionProductos<ProductosPanaderia>
    {
        public ProductosPanaderia() :base(0,"",0,0,0)
        {

        }
        public ProductosPanaderia(int codigo, string nombre, double precioPorKilo, int cantidad, float peso) : base(codigo, nombre, precioPorKilo, cantidad, peso)
        {
            this.precioFinalPesado = base.precioFinalPesado;
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

        public new float Peso
        {
            get { return base.Peso; }
            set { base.Peso = value; }
        }

        public new double PrecioFinalPesado
        {
            get { return precioFinalPesado; }
            set { PrecioFinalPesado = value; }
        }

        public override string Mostrar()
        {
            return $"Producto de Panaderia, su precio es ${this.precio} xKG, cantidad maxima de Kilos: 5";
        }

        ProductosPanaderia IConversionProductos<ProductosPanaderia>.ConvertirProductos(Producto producto)
        {
            ProductosPanaderia productoConvertido = new ProductosPanaderia(producto.Codigo, producto.Nombre, producto.Precio, producto.Cantidad, 1);
            return productoConvertido;
        }
    }
}
