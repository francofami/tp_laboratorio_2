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
        /// <summary>
        /// Si se quiere añadir un Paquete con un ID utilizado previamente saldrá esta excepción.
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrará.</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
            MessageBox.Show(mensaje);
        }

        /// <summary>
        /// Si se quiere añadir un Paquete con un ID utilizado previamente saldrá esta excepción.
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrará.</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : this(mensaje)
        {

        }
    }
}
