namespace Tiendas
{
    public abstract class Tienda
    {
        public string direccion;
        public int cantidadDeEmpleados;
        public string tipoDeproductos;

        /// <summary>
        /// Inicializa los atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="cantidadDeEmpleados"></param>
        /// <param name="tipoDeproductos"></param>
        public Tienda(string direccion, int cantidadDeEmpleados, string tipoDeproductos)
        {
            this.direccion = direccion;
            this.cantidadDeEmpleados = cantidadDeEmpleados;
            this.tipoDeproductos = tipoDeproductos;
        }

        protected abstract string DatosDeLatienda();

        /// <summary>
        /// Compara por tipo, cantidad de empleados y tipo de productos.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
