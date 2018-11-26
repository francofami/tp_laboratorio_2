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
