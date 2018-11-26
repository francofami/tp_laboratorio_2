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

        /// <summary>
        /// Hace que el paquete cambie de estado y llama a funcion que agrega sus datos en la base de datos
        /// </summary>
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

        /// <summary>
        /// Sobreescribe el método de la interfaz IMostrar. Muestra los datos del paquete recibido.
        /// </summary>
        /// <param name="elemento">Paquete a mostrar</param>
        /// <returns>Devuelve string con los datos del paquete.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = new Paquete(((Paquete)elemento).direccionEntrega, ((Paquete)elemento).trackingID);

            string retorno = "";

            retorno += string.Format("{0} para {1}\n", p.trackingID, p.direccionEntrega);

            return retorno;
        }

        /// <summary>
        /// Dos Paquetes son iguales si tienen el mismo trackingID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns>True si son iguales, false si no lo son.</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if(p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Dos Paquetes son iguales si tienen distinto trackingID
        /// </summary>
        /// <param name="p1">>Paquete a comparar</param>
        /// <param name="p2">>Paquete a comparar</param>
        /// <returns>True si son distintos, false si no lo son.</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            retorno = !(p1 == p2);

            return retorno;
        }

        /// <summary>
        /// Constructor de clase parametrizado.
        /// </summary>
        /// <param name="direccionEntrega">La direccion de entrega</param>
        /// <param name="trackingID">El trackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Muestra los datos del Paquete a excepción de su estado.
        /// </summary>
        /// <returns>Un string con los datos del paquete.</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("{0} para {1}\n", this.TrackingID, this.direccionEntrega);

            return retorno.ToString();
        }

    }
}
