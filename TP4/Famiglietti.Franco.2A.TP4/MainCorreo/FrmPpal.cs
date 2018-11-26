using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo = new Correo();

        /// <summary>
        /// Limpia los listbox y agrega los paquetes en cada listado correspondiente
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach(Paquete paq in this.correo.Paquetes)
            {
                switch(paq.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        {
                            this.lstEstadoEntregado.Items.Add(paq);
                        }
                        break;
                    case Paquete.EEstado.EnViaje:
                        {
                            this.lstEstadoEnViaje.Items.Add(paq);
                        }
                        break;
                    case Paquete.EEstado.Ingresado:
                        {
                            this.lstEstadoIngresado.Items.Add(paq);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Añade un Paquete al correo de la clase actual y llama al método ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += this.paq_InformaEstado;

            try
            {
                this.correo += paquete;
            }
            catch(TrackingIdRepetidoException)
            {
                
            }

            this.ActualizarEstados();
        }

        /// <summary>
        /// Muestra todos los Paquetes presentes en el Correo de la clase actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        public FrmPpal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al cerrar la aplicación se llama al método FinEntregas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.correo.FinEntregas();
        }
        
        /// <summary>
        /// Muestra los datos de elemento siempre y cuando sea distinto de null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            try
            {
                if (!(Object.Equals(elemento, null)))
                {
                    this.rtbMostrar.Text = "";

                    if (elemento is Paquete)
                    {
                        this.rtbMostrar.Text += elemento.ToString();
                    }
                    else
                    {
                        this.rtbMostrar.Text += elemento.MostrarDatos(elemento);
                    }

                    GuardaString.Guardar(this.rtbMostrar.Text, "salida.txt");
                }
            }
            catch(Exception e)
            {

            }        
        }
        
        /// <summary>
        /// Informa el estado actual de un Paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Muestra un objeto entregado seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
