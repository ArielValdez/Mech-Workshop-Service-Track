using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql()
        {
            // Connection String to an Azure Database
            connectionString = "Server=proyectofinal-server.database.windows.net;Database=Db administrador;User Id=Administrador;password=Admin12345@.;integrated security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
