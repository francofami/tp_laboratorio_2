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
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                StreamWriter sw = new StreamWriter(archivo);
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
