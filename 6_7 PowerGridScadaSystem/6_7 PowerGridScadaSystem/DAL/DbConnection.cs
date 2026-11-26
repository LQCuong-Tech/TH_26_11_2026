using System.Data.SqlClient;

namespace _6_7_PowerGridScadaSystem.DAL
{
    public static class DbConnectionHelper
    {
        private static readonly string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=ScadaDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}