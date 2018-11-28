using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad de escritura, llama a Validar numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">El numero binario a ser convertido</param>
        /// <returns>El numero decimal</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno="";
            int numConvertido = 0;
            bool flag = false;

            char[] bit = binario.ToCharArray();
            Array.Reverse(bit);
            
            for (int i = 0; i < bit.Length; i++)
            {
                if(bit[i] == '1' || bit[i] == '0')
                {
                    flag = true;
                }

                if (bit[i] == '1')
                {
                    numConvertido += (int)Math.Pow(2, i);
                }
            }

            if(flag == true)
            {
                retorno = numConvertido.ToString();
            }
            else
            {
                retorno = "Valor inválido.";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">El numero decimal (double) a ser convertido</param>
        /// <returns>El numero en binario</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "";

            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        retorno += "0";
                    }
                    else
                    {
                        retorno += "1";
                    }

                    numero = (int)(numero / 2);
                }

                char[] charArray = retorno.ToCharArray();
                Array.Reverse(charArray);
                retorno = new string(charArray);

            }
            else
            {
                retorno = "Valor inválido.";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">El numero decimal (string) a ser convertido</param>
        /// <returns>El numero en binario</returns>
        public string DecimalBinario(string numero)
        {
            string retorno="";
            double numeroAConvertir;

            double.TryParse(numero, out numeroAConvertir);

            if (numeroAConvertir > 0)
            {
                while (numeroAConvertir > 0)
                {
                    if (numeroAConvertir % 2 == 0)
                    {
                        retorno += "0";
                    }
                    else
                    {
                        retorno += "1";
                    }

                    numero = (numeroAConvertir / 2).ToString();
                }

                char[] charArray = retorno.ToCharArray();
                Array.Reverse(charArray);
                retorno = new string(charArray);

            }
            else
            {
                retorno = "Valor inválido.";
            }

            return retorno;
        }

        /// <summary>
        /// Constructor de clase por defecto, llama a otro contructor pasandole un 0
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="numero">Numero (double)</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="numero">Numero (string)</param>
        public Numero(string strNumero)
        {
            double.TryParse(strNumero, out this.numero);
        }

        /// <summary>
        /// Resta entre dos numeros
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>El resultado de la resta.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero - n2.numero;

            return retorno;            
        }

        /// <summary>
        /// Multiplicación entre dos numeros
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>El resultado de la multiplicación.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero * n2.numero;

            return retorno;
        }

        /// <summary>
        /// División entre dos numeros
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>Resultado de la division. Si es division por 0 devuelve double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno;

            if (n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        /// <summary>
        /// Suma entre dos numeros
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>El resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero + n2.numero;

            return retorno;
        }

        /// <summary>
        /// Valida que el valor recibido sea numérico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El numero validado en caso de ser numerico, de lo contrario 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            if(double.TryParse(strNumero, out retorno) == false)
            {
                retorno = 0;
            }    

            return retorno;
        }
    }
}
