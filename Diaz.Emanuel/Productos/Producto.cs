using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class Producto
    {
        public int codigo;
        public string? nombre = "";
        public double precio;
        public int cantidad;

        public Producto() { }

        /// <summary>
        /// Le asiga a los atributos los valores pasados por parametro.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(int codigo, string nombre, double precio, int cantidad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string? Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        /// <summary>
        /// Muestra datos del producto
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return $"{this.nombre} {this.precio} {this.cantidad}";
        }

        public static bool operator == (Producto primerProducto, Producto segundoProducto)
        {
            bool retorno = false;
            if (ReferenceEquals(primerProducto, null) || ReferenceEquals(segundoProducto, null))
            {
                return false;
            }
            if (primerProducto.Codigo == segundoProducto.Codigo || primerProducto.Nombre == segundoProducto.Nombre)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Producto primerProducto, Producto segundoProducto)
        {
            return !(primerProducto == segundoProducto);
        }
    }
}
