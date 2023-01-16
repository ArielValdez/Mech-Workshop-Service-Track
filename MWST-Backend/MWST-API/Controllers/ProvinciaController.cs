using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MWST_API.Controllers
{
    [Route("api/Provincia")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public ProvinciaController()
        {
            
        }

        [Route("getProvincia")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select * from tblProvincia";

            DataTable table = new DataTable();
            // Check if does not return connection string
            string sqlDataSource = con.ReturnConnection().ConnectionString;
            SqlDataReader reader;
            try
            {
                // Use the domain instead
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                error.Success();
                return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Vehicle get!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("postProvincia")]
        [HttpPost]
        public JsonResult Post()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Post Request.");
            }
        }

        [Route("putProvincia")]
        [HttpPut]
        public JsonResult Put()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Put Request.");
            }
        }

        [Route("deleteProvincia")]
        [HttpDelete]
        public JsonResult Delete()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Delete Request.");
            }
        }
    }
}
