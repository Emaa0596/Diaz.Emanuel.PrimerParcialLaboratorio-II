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
        public Producto(int codigo, string nombre, double precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = 0;
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

        public string Mostrar()
        {
            return $"{this.nombre}        \t\t\t${this.precio}\t\t\t\t  {this.cantidad}";
        }

    }
}
