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

        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Documento del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Documento del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno</param>
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

            retorno.AppendLine(base.MostrarDatos() + this.ParticiparEnClase());

            switch(this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    {
                        retorno.AppendLine("ESTADO DE CUENTA: Cuota al día");
                    }
                    break;
                case EEstadoCuenta.Becado:
                    {
                        retorno.AppendLine("ESTADO DE CUENTA: Becado");
                    }
                    break;
                case EEstadoCuenta.Deudor:
                    {
                        retorno.AppendLine("ESTADO DE CUENTA: Deudor");
                    }
                    break;
            }
    
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
        /// Crea string con la clase en la que participa el alumno
        /// </summary>
        /// <returns>string con la clase en la que participa el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("TOMA CLASES DE " + this.claseQueToma);

            return retorno.ToString();
        }

        /// <summary>
        /// Crea string con los datos de Alumno
        /// </summary>
        /// <returns>String con los datos de Alumno</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(this.MostrarDatos());

            return retorno.ToString();
        }
    }
}
