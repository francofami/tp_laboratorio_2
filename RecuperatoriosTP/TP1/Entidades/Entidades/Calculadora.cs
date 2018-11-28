using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador sea +, -, * o /.
        /// </summary>
        /// <param name="operador">El operador a validar</param>
        /// <returns>Retorna el operador recibido, en caso de no ser +, -, / o * retornará +.</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "";

            switch(operador)
            {
                case "+":
                    {
                        retorno = "+";
                    }
                    break;
                case "-":
                    {
                        retorno = "-";
                    }
                    break;
                case "/":
                    {
                        retorno = "/";
                    }
                    break;
                case "*":
                    {
                        retorno = "*";
                    }
                    break;
                default:
                    {
                        retorno = "+";
                    }
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Efectúa la operación entre dos Numeros
        /// </summary>
        /// <param name="num1">numero 1</param>
        /// <param name="num2">numero 2</param>
        /// <param name="operador">+, -, * o /</param>
        /// <returns>El resultado de la operación.</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno=-1;

            operador = ValidarOperador(operador);

            switch(operador)
            {
                case "+":
                    {
                        retorno = num1 + num2;
                    }
                    break;
                case "-":
                    {
                        retorno = num1 - num2;
                    }
                    break;
                case "/":
                    {
                        retorno = num1 / num2;
                    }
                    break;
                case "*":
                    {
                        retorno = num1 * num2;
                    }
                    break;
            }

            return retorno;
        }
    }
}
