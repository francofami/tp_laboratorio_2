using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        
        /// <summary>
        /// Verifica que el objeto de la instancia sea del mismo tipo que el objeto pasado por parametro
        /// </summary>
        /// <param name="obj"> El objeto a comparar</param>
        /// <returns>Devuelve true en caso de que ambos objetos sean del mismo tipo</returns>
        public bool Equals(object obj)
        {
            bool retorno = false;

            retorno = this.GetType() == obj.GetType();

            return retorno;
        }

        /// <summary>
        /// Retorna un string con los datos de Persona y Universitario
        /// </summary>
        /// <returns>Retorna un string con los datos de Persona y Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.ToString());
            retorno.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return retorno.ToString();
        }

        /// <summary>
        /// Chuequea que dos Universitarios sean iguales
        /// </summary>
        /// <param name="pg1">Universitario 1 a comparar con Universitario 2</param> 
        /// <param name="pg2">Universitario 2 a comparar con Universitario 1</param> 
        /// <returns>True si son iguales (mismo tipo de objeto y mismo dni o legajo)</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Chequea que dos Universitarios sean distintos
        /// </summary>
        /// <param name="pg1">Universitario 1 a comparar con Universitario 2</param>
        /// <param name="pg2">Universitario 2 a comparar con Universitario 1</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            retorno = !(pg1 == pg2);

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
