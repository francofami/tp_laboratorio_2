using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="nombre">Nombre de Persona</param>
        /// <param name="apellido">Apellido de Persona</param>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="nombre">Nombre de Persona</param>
        /// <param name="apellido">Apellido de Persona</param>
        /// <param name="dni">Documento de Persona</param>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="nombre">Nombre de Persona</param>
        /// <param name="apellido">Apellido de Persona</param>
        /// <param name="dni">Documento de Persona</param>
        /// <param name="nacionalidad">Nacionalidad de Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Retorna un string con los datos de la persona
        /// </summary>
        /// <returns>Retorna un string con los datos de la persona</returns> 
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("NOMBRE COMPLETO: " + this.apellido + ", " + this.nombre);
            retorno.AppendLine("NACIONALIDAD: " + this.nacionalidad);

            return retorno.ToString();
        }

        /// <summary>
        /// Valida que el dni ingresado se encuentre dentro de los rangos permitidos según nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param> La nacionalidad del dni de la persona 
        /// <param name="dato"></param> El dni a validar
        /// <returns>Devuelve el dni si no hay error, caso contrario lanza una excepcion.</returns> 
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato < 1 || dato > 89999999)
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            else
            {
                if (dato < 89999999 || dato > 99999999)
                {
                    throw new NacionalidadInvalidaException();
               } 
            }

            return dato;
        }

        /// <summary>
        /// Valida que el numero de DNI no se exceda de los rangos estipulados y de cumplir con esa condicion lo pasa a entero
        /// </summary>
        /// <param name="nacionalidad"></param> La nacionalidad
        /// <param name="dato"></param> El numero de dni
        /// <returns>El DNI validado en formato int</returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            int dni;

            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException(dato.ToString());
            }
            else
            {
                try
                {
                    dni = int.Parse(dato);
                }
                catch (Exception e)
                {
                    throw new DniInvalidoException(dato.ToString(), e);
                }
            }

            retorno = ValidarDni(nacionalidad, dni);

            return retorno;
        }

        /// <summary>
        /// Valida que el nombre/apellido ingresado contenga solamente letras minusculas y/o mayusculas
        /// </summary>
        /// <param name="dato">El nombre/apellido a validar</param>
        /// <returns></returns>
        string ValidarNombreApellido(string dato)
        {
            string retorno = "";

            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
            {
                retorno = dato;
            }

            return retorno;
        }
    }
}
