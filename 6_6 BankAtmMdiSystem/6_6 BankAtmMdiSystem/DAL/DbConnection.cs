using System.Data.SqlClient;

namespace _6_6_BankAtmMdiSystem.DAL
{
    public static class DbConnectionHelper
    {
        private static readonly string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=BankAtmDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}