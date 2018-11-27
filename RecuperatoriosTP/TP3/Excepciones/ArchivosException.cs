using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception e) : base("Error.", e)
        {
            Console.WriteLine("Se produjo un error al intentar guardar/leer el archivo.");
        }
    }
}
