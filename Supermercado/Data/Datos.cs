using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.Data
{
    internal class Datos
    {
        private string connectionString =
            "Host=localhost;Username=admin;Password=12345;" +
            "Database=Topicos";
        private NpgsqlConnection GetConnection()
        {
            try
            {
                NpgsqlConnection connection =
                    new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al " +
                    "conectar a la base de datos: " + ex.Message);
                return null;
            }
        }

        public bool ExecuteQuery(string query)
        {
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(query, GetConnection());
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                return false;
            }
        }
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    if (connection != null && connection.State ==
                        System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Conexión exitosa a la base de datos.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No se pudo establecer la conexión.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al probar la conexión: " + ex.Message);
                return false;
            }
        }

        public DataSet getAllData(String command)
        {
            DataSet dataSet = new DataSet();
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command, GetConnection());
                da.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los datos: " + ex.Message);
                return null;
            }
        }
    }
}
