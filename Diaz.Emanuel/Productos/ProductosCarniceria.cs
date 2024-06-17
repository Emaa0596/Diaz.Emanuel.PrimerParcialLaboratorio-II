using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos
{
    public class ProductosCarniceria : Producto
    {
        public float peso;
        public double precioFinalPesado;

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

    }   

}
