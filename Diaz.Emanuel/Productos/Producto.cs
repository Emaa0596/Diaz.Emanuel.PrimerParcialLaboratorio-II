using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class Producto
    {
        private int codigo;
        private string nombre = "";
        private double precio;
        private int cantidad;

        public Producto()
        {

        }
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

        public string Nombre
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            return $"{this.nombre}        \t\t\t${this.precio}\t\t\t {this.cantidad}";
        }

        public static bool operator == (Producto primerProducto, Producto segundoProducto)
        {
            bool retorno = false;
            if (ReferenceEquals(primerProducto, null) || ReferenceEquals(segundoProducto, null))
            {
                return false;
            }
            if (primerProducto.Codigo == segundoProducto.Codigo && primerProducto.Nombre == segundoProducto.Nombre)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Producto primerProducto, Producto segundoProducto)
        {
            return !(primerProducto == segundoProducto);
        }

        public ProductosAlmacen ConvertirProductoAlmacen()
        {
            ProductosAlmacen nuevoProducto = new ProductosAlmacen(this.Codigo, this.Nombre, this.Precio, this.Cantidad);
            return nuevoProducto;
        }

        public ProductosCarniceria ConvertirProductoCarniceria()
        {
            ProductosCarniceria nuevoProducto = new ProductosCarniceria(this.Codigo, this.Nombre, this.Precio, this.Cantidad,1);
            return nuevoProducto;
        }

        public ProductosPanaderia ConvertirProductoAPanaderia()
        {
            ProductosPanaderia nuevoProducto = new ProductosPanaderia(this.Codigo, this.Nombre, this.Precio, this.Cantidad,1);
            return nuevoProducto;
        }


    }
}
