using System.Data;
using Npgsql;

namespace SourceCode1
{
    public class Conexion
    {
        private static string sConection =
            "Server=localhost;Port=5432;User Id=postgres;Password=uca;Database=examen2";

        public static DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection conection = new NpgsqlConnection(sConection);
            DataSet ds = new DataSet();
            conection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conection);
            da.Fill(ds);
            conection.Close();
            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConection);
            connection.Open();
            NpgsqlCommand com = new NpgsqlCommand(act, connection);
            com.ExecuteNonQuery();
            connection.Close();
        }
    }
}