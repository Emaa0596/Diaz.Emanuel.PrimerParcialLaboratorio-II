namespace Tiendas
{
    public class Tienda
    {
        public string direccion;
        public int cantidadDeEmpleados;
        public string tipoDeproductos;


        public Tienda(string direccion, int cantidadDeEmpleados, string tipoDeproductos)
        {
            this.direccion = direccion;
            this.cantidadDeEmpleados = cantidadDeEmpleados;
            this.tipoDeproductos = tipoDeproductos;
        }
    }
}
