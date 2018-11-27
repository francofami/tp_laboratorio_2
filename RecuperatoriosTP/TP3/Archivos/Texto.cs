using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        /// <summary>
        /// Guarda los datos de la clase en un archivo de texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna true si no hay errores al guardar, caso contrario retorna false.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);
                sw.WriteLine(datos);
                sw.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos que contiene un archivo de texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Datos a leer</param>
        /// <returns>Retorna true si no hay errores al leer, caso contrario retorna false.</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
