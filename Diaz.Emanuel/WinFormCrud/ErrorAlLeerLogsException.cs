using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCrud
{
    internal class ErrorAlLeerLogsException : Exception
    {
        public ErrorAlLeerLogsException() :base("No se pudieron cargar los datos. Archivo Inexistente") { }
    }
}
