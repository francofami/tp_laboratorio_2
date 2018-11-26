using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public TrackingIdRepetidoException(string mensaje, Exception inner) : this(mensaje)
        {

        }
    }
}
