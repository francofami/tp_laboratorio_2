﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
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
