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

        /// <summary>
        /// Inicializa con valores minimos los atributos en la clase padre.
        /// </summary>
        public ProductosCarniceria() : base(0, "", 0, 0) 
        { 
            this.peso = 0; this.precioFinalPesado = 0;
        }

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
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

        public float Peso
        {
            get { return peso; }
            set { Peso = value; } 
        }

        public double PrecioFinalPesado
        {
            get { return precioFinalPesado; }
            set { PrecioFinalPesado = value; }
        }

        /// <summary>
        /// Muestra los datos del producto. Se aplica polimorfismo. 
        /// </summary>
        /// <returns>String con descripcion del producto. </returns>
        public override string Mostrar()
        {
            return $"Producto de carniceria, su precio es ${this.precio} xKG, se puede adquirir una cantidad maxima de 5 Kilos";
        }

        /// <summary>
        /// Convierte el producto pasado por parametro a producto Carniceria. Se implementa la interfaz.
        /// </summary>
        /// <param name="producto">Producto</param>
        /// <returns>Producto casteado a Carniceria.</returns>
        public ProductosCarniceria ConvertirProductos(Producto producto)
        {
            ProductosCarniceria productoConvertido = new ProductosCarniceria(producto.Codigo, producto.Nombre, producto.Precio, producto.Cantidad, 1);
            return productoConvertido;
        }
    }   

}
