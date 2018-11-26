using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor de clase que inicializa la lista de paquetes y la lista de hilos.
        /// </summary>
        public Correo()
        {           
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        /// <summary>
        /// Termina la ejecución de todos los hilos que haya en el programa.
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread thread in this.mockPaquetes)
            {
                thread.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos de todos los paquetes contenidos en una lista de paquetes.
        /// </summary>
        /// <param name="elementos">La lista que contiene paquetes.</param>
        /// <returns>String con los datos de todos los paquetes contenidos en una lista de paquetes.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = "";

            foreach (Paquete p in ((Correo) elementos).paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return retorno;
        }

        /// <summary>
        /// Agrega un paquete al correo. En caso de estar repetido lanza una excepción.
        /// </summary>
        /// <param name="c">Correo que contiene lista de paquetes en el cual voy a agregar el parámetro recibido de tipo Paquete.</param>
        /// <param name="p">Paquete a agregar al correo.</param>
        /// <returns>Retorna parámetro recibido de tipo Correo con el paquete agregado a su lista de paquetes.</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            int flag = 0;

            foreach (Paquete paq in c.paquetes)
            {
                if (paq == p)
                {
                    flag = 1;
                    throw new TrackingIdRepetidoException("El Tracking ID " + paq.TrackingID + " ya figura en la lista de envíos.");
                    break;
                }
            }               
        
            if(flag == 0)
            {
                c.paquetes.Add(p);
                Thread thread = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(thread);
                thread.Start();
            }

            return c;            
        }
    }
}
