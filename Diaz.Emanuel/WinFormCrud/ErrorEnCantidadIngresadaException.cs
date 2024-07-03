using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCrud
{
    internal class ErrorEnCantidadIngresadaException : Exception
    {
        public ErrorEnCantidadIngresadaException() : base("La cantidad ingresada no puede ser menor a 0 ni mayor a 5, si es negativa se ingresaran 0 cantidades, si es mayor a 5 quedara en su cantidad maxima (5)") { }
    }
}
