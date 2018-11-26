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

        public Correo()
        {           
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach(Thread thread in this.mockPaquetes)
            {
                thread.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = "";

            foreach (Paquete p in ((Correo) elementos).paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return retorno;
        }

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
