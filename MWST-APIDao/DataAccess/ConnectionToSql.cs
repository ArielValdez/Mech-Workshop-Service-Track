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
            connectionString = "Server=db-mwst.chi0aivlb8yi.us-east-2.rds.amazonaws.com;Database=MWSTdb;User Id=admin;password=Grupo4IDS333;integrated security=false";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
