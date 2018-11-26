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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string operador;
            string num1;
            string num2;
            double resultado;

            num1 = this.txtNumero1.Text;
            num2 = this.txtNumero2.Text;
            operador = this.cmbOperador.SelectedItem.ToString();

            resultado = Operar(num1, num2, operador);

            this.lblResultado.Text = resultado.ToString();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado;

            Numero aDecimal = new Numero();

            resultado = aDecimal.BinarioDecimal(this.lblResultado.Text);

            this.lblResultado.Text = resultado;
        }
    }
}
