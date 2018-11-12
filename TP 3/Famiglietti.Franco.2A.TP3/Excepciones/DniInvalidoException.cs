using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "¡Error! no se ingresó un número válido.";

        public DniInvalidoException() : base(mensajeBase)
        {

        }

        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        {

        }

        public DniInvalidoException(string message) : base(mensajeBase + message)
        {

        }

        public DniInvalidoException(string message, Exception e) :base(mensajeBase + message, e)
        {

        }
    }
}
