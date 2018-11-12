using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Crea string con los datos de Alumno y de Universitario
        /// </summary>
        /// <returns>String con los datos de Alumno y de Universitario</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine(this.ToString());

            return retorno.ToString();
        }

        /// <summary>
        /// Comprueba que Alumno y EClases sean iguales.
        /// </summary>
        /// <param name="a">El alumno</param>
        /// <param name="clase">La clase </param>
        /// <returns>True si son iguales</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if(a.claseQueToma == clase && a.estadoCuenta!=EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Comprueba que Alumno y clases sean distintas.
        /// </summary>
        /// <param name="a">El alumno</param>
        /// <param name="clase">La clase</param>
        /// <returns>False si son distintos</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            retorno = !(a.claseQueToma == clase);

            return retorno;
        }

        /// <summary>
        /// Crea string con los datos de Alumno
        /// </summary>
        /// <returns>String con los datos de Alumno</returns>
        public string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("Clase que toma: " + this.claseQueToma);
            retorno.Append("Estado cuenta: " + this.estadoCuenta);

            return retorno.ToString();
        }
    }
}
