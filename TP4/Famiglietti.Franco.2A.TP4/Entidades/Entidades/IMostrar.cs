using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Las clases que implementaron esta interfaz (Correo y Paquete) van a sobreescribir este metodo mostrando los datos del parámetro elemento.
        /// </summary>
        /// <param name="elemento">El elemento a mostrar</param>
        /// <returns>Devuelve un string con los datos.</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
