using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        protected static Random random;

        /// <summary>
        /// Genera una clase al azar y la agrega a la lista de clases
        /// </summary>
        private void _randomClases()
        {
            for(int i=0; i<=1; i++)
            {
                Array values = Enum.GetValues(typeof(Universidad.EClases));
                Universidad.EClases claseRandom = (Universidad.EClases)values.GetValue(Profesor.random.Next(values.Length));
                clasesDelDia.Enqueue(claseRandom);
            }
            
        }

        /// <summary>
        /// Crea string con los datos del profesor
        /// </summary>
        /// <returns>Un string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos() + this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Verifica que un profesor sea igual a una clase (que el profesor dicte esa clase)
        /// </summary>
        /// <param name="i">El profesor</param>
        /// <param name="clase">La clase</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases claseActual in i.clasesDelDia)
            {
                if(claseActual == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica que un profesor sea distinto a una clase (que el profesor no dicte esa clase)
        /// </summary>
        /// <param name="i">El profesor</param>
        /// <param name="clase">La clase</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            retorno = !(i == clase);

            return retorno;
        }

        /// <summary>
        /// Crea un string con las clases que se dan en el dia
        /// </summary>
        /// <returns>Devuelve un string con las clases que se dan en el dia</returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "";

            retorno += "CLASES DEL DÍA: \n";

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                retorno += clase.ToString();
                retorno += "\n";
            }

            return retorno;
        }

        public Profesor()
        {

        }

        static Profesor()
        {
            Profesor.random = new Random(); 
        }
        
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns>Devuelve un string</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(this.MostrarDatos());

            return retorno.ToString();
        }
    }
}
