namespace Tiendas
{
    public abstract class Tienda
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

        protected abstract string DatosDeLatienda();

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj == null || this.GetType() != obj.GetType())
            {
                return retorno;
            }

            Tienda otraTienda = (Tienda)obj;
            if(this.cantidadDeEmpleados == otraTienda.cantidadDeEmpleados && this.tipoDeproductos == otraTienda.tipoDeproductos)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
