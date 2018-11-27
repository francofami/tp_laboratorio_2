using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Clases_Instanciables
{ 
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }

        
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;

            StreamWriter sw;
            sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Universidad.xml", false);
            XmlSerializer xml; 
            xml = new XmlSerializer(typeof(Universidad));

            try
            {
                xml.Serialize(sw, uni);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            sw.Close();

            return retorno;
        }

        /// <summary>
        /// Pasa los datos de los alumnos, profesores y jornadas a un string.
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>String con datos de los alumnos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("JORNADA: ");

            foreach (Jornada jor in uni.jornada)
            {
                retorno.AppendLine(jor.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Compara una Universidad con Alumno
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno esta en la universidad</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno alumno in g.alumnos)
            {
                if(alumno == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara una universidad con un profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve true si el profesor esta en la universidad</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor profe in g.profesores)
            {
                if (profe == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Busca si hay un profesor en la universidad dando determinada clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve el profesor que esta dando tal materia en caso de haberlo</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor retorno = new Profesor();

            int flag = 0;

            foreach (Profesor profe in g.profesores)
            {
                if (profe == clase)
                {
                    flag = 1;
                    retorno = profe;                  
                    break;
                }
            }

            if(flag==0)
            {
                throw new SinProfesorException();
            }         

            return retorno;
        }

        /// <summary>
        /// Compara una universidad con un alumno, si este esta o no en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>False si se encuentra</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            bool retorno = false;

            retorno = !(g == a);

            return retorno;
        }

        /// <summary>
        /// Compara una universidad con un profesor, si este esta o no en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Alumno</param>
        /// <returns>False si se encuentra</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            bool retorno = false;

            retorno = !(g == i);

            return retorno;
        }

        /// <summary>
        /// Chequea que un profesor no este dando una clase y lo devuelve en caso de encontrarlo
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>DEvuelve el primer profesor que no de la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor retorno = new Profesor();

            foreach (Profesor profe in g.profesores)
            {
                if (profe != clase)
                {
                    retorno = profe;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Si un alumno toma la clase recibida por parámetro, se agrega el alumno a una jornada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            int flag = 0;

            foreach(Profesor profe in g.profesores)
            {
                flag = 0;

                if(profe == clase)
                {
                    flag = 1;
                    Jornada jor = new Jornada(clase, profe);

                    foreach (Alumno alumno in g.alumnos)
                    {
                        if (alumno == clase)
                        {
                            jor += alumno;
                        }
                    }

                    g.jornada.Add(jor);
                }               
            }

            if(flag == 0)
            {
                throw new SinProfesorException();
            }

            return g;
        }

        /// <summary>
        /// Añade un alumno en la universidad siempre y cuando este no este
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u==a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                u.alumnos.Add(a);
            }            

            return u;
        }

        /// <summary>
        /// Añade un profesor en la universidad siempre y cueando este no este
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            int flag = 0;

            foreach (Profesor profe in u.profesores)
            {
                if (profe == i)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 0)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Hace publico el metodo MostrarDatos
        /// </summary>
        /// <returns>Un string con el contenido de MostrarDatos</returns>
        public override string ToString()
        {
            string retorno = "";

            retorno = MostrarDatos(this);

            return retorno;
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
    }
}
