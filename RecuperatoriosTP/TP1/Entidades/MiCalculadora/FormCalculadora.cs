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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor de clase.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");

        }

        /// <summary>
        /// Llama a la propiedad de escritura de la clase Numero para validar los numeros recibidos y al metodo operar de la clase Calculadora para hacer la operación.
        /// </summary>
        /// <param name="numero1">Numero 1</param>
        /// <param name="numero2">Numero 2</param>
        /// <param name="operador">+, -, * o /</param>
        /// <returns>El resultado de la operación.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno=0;

            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            Calculadora calc = new Calculadora();

            num1.SetNumero = numero1;
            num2.SetNumero = numero2;

            retorno = calc.Operar(num1, num2, operador);

            return retorno;
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Botón que llama al método DecimalBinario de la clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            double numero;
            string resultado;

            Numero aBinario = new Numero();

            if(this.txtNumero1.Text != "0")
            {
                double.TryParse(this.lblResultado.Text, out numero);
                resultado = aBinario.DecimalBinario(numero);
            }
            else
            {
                resultado = 0.ToString();
            }

            this.lblResultado.Text = resultado;
        }

        /// <summary>
        /// Botón que llama al método BinarioDecimal de la clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado;

            Numero aDecimal = new Numero();

            resultado = aDecimal.BinarioDecimal(this.lblResultado.Text);

            this.lblResultado.Text = resultado;
        }

        /// <summary>
        /// Botón que llama al método Limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Botón que llama al método operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            string num1;
            string num2;
            double resultado;

            num1 = this.txtNumero1.Text;
            num2 = this.txtNumero2.Text;
            operador = this.cmbOperador.Text.ToString();

            resultado = Operar(num1, num2, operador);

            this.lblResultado.Text = resultado.ToString();
        }
    }
}
