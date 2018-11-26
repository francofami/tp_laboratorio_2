using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-")
            {
                retorno = "-";
            }

            if (operador == "/")
            {
                retorno = "/";
            }

            if (operador == "*")
            {
                retorno = "*";
            }

            return retorno;
        }

        public double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno=-1;

            operador = ValidarOperador(operador);



            if (operador == "+")
                   retorno = num1 + num2;

                if(operador == "-")
                   retorno = num1 - num2;

                if(operador == "/")
                   retorno = num1 / num2;

                if(operador == "*")
                   retorno = num1 * num2;

            return retorno;
        }
    }
}
