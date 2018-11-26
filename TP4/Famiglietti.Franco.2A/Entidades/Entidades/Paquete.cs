using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        public event DelegadoEstado InformaEstado;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }

        public void MockCicloDeVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);

                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        {
                            this.estado = EEstado.EnViaje;
                        }
                        break;
                    case EEstado.EnViaje:
                        {
                            this.estado = EEstado.Entregado;
                        }
                        break;
                }

                this.InformaEstado(this, new EventArgs());
            }

            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = "";

            foreach (Paquete p in ((Correo)elemento).Paquetes)
            {
                retorno += string.Format("{0} para {1}\n", p.trackingID, p.direccionEntrega);
            }

            return retorno;
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if(p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            retorno = !(p1 == p2);

            return retorno;
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("{0} para {1}\n", this.TrackingID, this.direccionEntrega);

            return retorno.ToString();
        }

    }
}
