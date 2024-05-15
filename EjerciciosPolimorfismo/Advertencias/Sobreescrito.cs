using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advertencias
{
    public abstract class Sobreescrito
    {
        protected string miAtributo;
        public Sobreescrito()
        {
            this.miAtributo = "Probar abstractos"; 
        }

        public abstract string MiPropiedad
        {
            get;
        }

        public abstract string MiMetodo();


        public override string ToString()
        {
            return "¡Este es mi método ToString sobrescrito!";
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Sobreescrito)
            {
                retorno = true;
            }
            return retorno;
        }

        public override int GetHashCode()
        {
            return 1142510181;
        }
    }
}
