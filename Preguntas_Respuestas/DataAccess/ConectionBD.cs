using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preguntas_Respuestas.DataAccess
{
    public class ConectionBD
    {
        private static string strConn = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=PreguntasRespuestas;Integrated Security=True;";

        public static SqlConnection GetSqlConnection()
        {
            try
            {
                string CONNECTION_STRING = strConn;
                var connection = new SqlConnection(CONNECTION_STRING);
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la conexión SQL: " + ex.Message);
                return null;
            }
        }
    }
}
