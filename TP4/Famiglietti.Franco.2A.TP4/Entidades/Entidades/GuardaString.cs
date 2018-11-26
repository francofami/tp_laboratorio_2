using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda texto en un archivo en el escritorio
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo de texto a guardar</param>
        /// <returns>Retorna true en caso de que no haya errores y false si es que los hay.</returns>
        static public bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;

            try
            {
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + archivo, true);
                sw.WriteLine(texto);
                sw.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                
            }

            return retorno;
        }
    }
}
