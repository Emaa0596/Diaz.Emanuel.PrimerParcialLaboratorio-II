using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCrud
{
    internal class ErrorEnCantidadIngresadaException : Exception
    {
        public ErrorEnCantidadIngresadaException() : base("La cantidad ingresada no puede ser negativa, se configurara en 0") { }
    }
}
