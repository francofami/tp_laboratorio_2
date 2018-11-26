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

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

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

        public Numero() : this(0)
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            double.TryParse(strNumero, out this.numero);
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero - n2.numero;

            return retorno;            
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero * n2.numero;

            return retorno;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero / n2.numero;

            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero + n2.numero;

            return retorno;
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero,out retorno);

            return retorno;
        }
    }
}
