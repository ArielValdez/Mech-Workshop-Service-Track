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
using MWST_API.Models;

namespace MWST_API.Controllers
{
    [Route("api/Workshop")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public WorkshopController()
        {
            
        }

        [Route("getWorkshop{id}")]
        [HttpGet]
        public JsonResult Get(int idWorkshop)
        {
            // Query to select the data needed. Change to stored procedures
            DataTable query = models.CheckWorkshop(idWorkshop);

            try
            {
                if (query != null && query.Rows.Count > 0)
                {
                    error.Success();
                    return new JsonResult(query);
                }
                else
                {
                    return new JsonResult("Not all fields have been filled");
                }
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        // Adds information into the database
        /* Data access to register a workshop does not exist
        [Route("postWorkshop")]
        [HttpPost]
        public JsonResult Post(WorkShop workShop)
        {
            // Query to insert the data needed
            bool query = models.RegisterWorkshop();

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;
            
            try
            {
                if (query)
                {
                    using (SqlConnection connection = new SqlConnection(sqlDataSource))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand())
                        {
                            reader = command.ExecuteReader();
                            table.Load(reader);
                            reader.Close();
                            connection.Close();
                        }
                    }
                    return new JsonResult(table);
                }
                else
                {
                    return new JsonResult("Not all parameters have been filled.");
                }
            }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get Exception Type: {0}", e.GetType());
                    Console.WriteLine("  Message: {0}", e.Message);
                    return new JsonResult("An error has occurred during Post Request.");
                }  
        */

        // Updates the information of the user. INCOMPLETE
        [Route("putWorkshop")]
        [HttpPut]
        public JsonResult Put(WorkShop workShop)
        {
            // Create, later, a data access for and to update
            // Query to update the information of the user

            string query = @"update tblTaller_Mecanico
                             set Nombre_Taller = @taller, Encargado = @encarcago
                             where ID_Taller = @idTaller";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            // Use the domain instead
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idTaller", workShop.ID_WorkShop);
                        command.Parameters.AddWithValue("@taller", workShop.Name_WorkShop);
                        command.Parameters.AddWithValue("@encarcago", string.Empty); // Check later

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                error.Success();
                return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Workshop get!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("deleteWorkshop")]
        [HttpDelete]
        public JsonResult Delete()
        {
            try
            {
                return new JsonResult("Not implemented yet");
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
