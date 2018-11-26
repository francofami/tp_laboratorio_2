using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;


namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Conecta y escribe los datos de un Paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete a escribir</param>
        /// <returns>Devolverá true si se puedo escribir, caso contrario devolverá false.</returns>
        public static bool Insertar(Paquete p)
        {
            //PaqueteDAO.conexion = new SqlConnection(@"Data Source=DESKTOP-FL4TN9S\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");

            ClassLibrary1.Properties.Settings config = new ClassLibrary1.Properties.Settings();

            PaqueteDAO.conexion = new SqlConnection(config.Conexion);  

            bool retorno = false;

            try
            {
                PaqueteDAO.comando = new SqlCommand();
                PaqueteDAO.comando.CommandType = CommandType.Text;
                PaqueteDAO.comando.Connection = conexion;

                PaqueteDAO.comando.CommandText = string.Format("INSERT INTO dbo.Paquetes ([direccionEntrega], [trackingID], [alumno]) values ('{0}','{1}','Franco Famiglietti')", p.DireccionEntrega, p.TrackingID);  

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                PaqueteDAO.conexion.Close();
                retorno = true;
            }

            catch(Exception e)
            {
                MessageBox.Show("No se ha podido conectar con la base de datos.");
            }

            return retorno;
        }

        static PaqueteDAO()
        {   
            
        }
    }
}
