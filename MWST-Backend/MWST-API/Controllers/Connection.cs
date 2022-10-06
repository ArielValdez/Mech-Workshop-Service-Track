using DataAccess;
using System.Data.SqlClient;

namespace MWST_API.Controllers
{
    public class Connection : ConnectionToSql
    {
        public SqlConnection ReturnConnection()
        {
            return GetConnection();
        }
    }
}
