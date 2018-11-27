﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">La jornada a ser guardada</param>
        /// <returns>True si no hubo error al guardar el archivo, false si lo hubo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;

            try
            {
                Texto txt = new Texto();

                txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", jornada.ToString());

                retorno = true;
            }

            catch (Exception e)
            {
                retorno = false;
            }


            return retorno;
        }

        /// <summary>
        /// Constructor de clase. Inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de clase parametrizado
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto
        /// </summary>
        /// <returns>String con los datos de la jornada</returns>
        public string Leer()
        {
            string retorno = "";

            StreamReader sw;

            sw = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\datosJornada.txt", false);

            try
            {
                retorno = sw.ReadToEnd();
                sw.Close();
            }

            catch (Exception e)
            {
                retorno = "Error al intentar leer los datos de la jornada.";
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Verifica que una jornada sea igual a un alumno (el alumno esté en la jornada)
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si está, sino false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno alum in j.alumnos)
            {
                if(alum == a)
                {
                    retorno = true;
                }
            }
            
            return retorno;
        }

        /// <summary>
        /// Verifica que una jornada sea distinta a un alumno (el alumno no esté en la jornada)
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>False está,caso contrario true.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            bool retorno = false;

            retorno = !(j == a);

            return retorno;
        }

        /// <summary>
        /// Si el alumno no estaba en la jornada se lo agrega
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>La jornada recibida por parametro</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Pasa los datos de la jornada a un string
        /// </summary>
        /// <returns>Un string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASE DE " + this.clase + " POR " + this.instructor);
            retorno.AppendLine("ALUMNOS: ");

            if(this.alumnos.Count != 0)
            {
                foreach (Alumno a in this.alumnos)
                {
                    retorno.AppendLine(a.ToString());
                }
            }
            else
            {
                retorno.AppendLine("No hay alumnos para esta clase.");
            }

            retorno.AppendLine("<---------------------------------------------------->");

            return retorno.ToString();
        }
    }
}
