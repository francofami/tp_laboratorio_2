using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    class Xml<T>
    {
        /// <summary>
        /// Guarda los datos de la clase en un archivo xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna true si no hay errores al guardar, caso contrario retorna false.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                XmlTextWriter tw = new XmlTextWriter(archivo, Encoding.UTF32);
                sr.Serialize(tw, datos);
                tw.Close();
                retorno = true; 
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos que contiene un archivo xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Datos a leer</param>
        /// <returns>Retorna true si no hay errores al leer, caso contrario retorna false.</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                XmlTextReader tr = new XmlTextReader(archivo);
                datos = (T)sr.Deserialize(tr);
                tr.Close();
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
