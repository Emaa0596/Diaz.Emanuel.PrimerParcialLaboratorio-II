using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosCarniceria : Producto, IConversionProductos<ProductosCarniceria>
    {
        public float peso;
        public double precioFinalPesado;

        public ProductosCarniceria() : base(0, "", 0, 0) 
        { 
            this.peso = 0; this.precioFinalPesado = 0;
        }
        public ProductosCarniceria(int codigo, string nombre, double precioPorKilo, int cantidad , float peso) :base(codigo, nombre, precioPorKilo,cantidad)
        {
            this.peso = peso;
            this.precioFinalPesado = base.Precio * this.peso;
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
            get { return peso; }
            set { Peso = value; } 
        }

        public new double PrecioFinalPesado
        {
            get { return precioFinalPesado; }
            set { PrecioFinalPesado = value; }
        }

        public ProductosCarniceria ConvertirProductos(Producto producto)
        {
            ProductosCarniceria productoConvertido = new ProductosCarniceria(producto.Codigo, producto.Nombre, producto.Precio, producto.Cantidad, 1);
            return productoConvertido;
        }
    }   

}
