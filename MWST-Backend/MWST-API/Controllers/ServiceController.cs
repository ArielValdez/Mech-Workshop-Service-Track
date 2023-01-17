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
    [Route("api/Service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public ServiceController()
        {
            
        }

        [Route("getService{id}")]
        [HttpGet]
        public JsonResult Get(int idService)
        {
            // Query to select the data needed. Change to stored procedures
            DataTable query = models.CheckService(idService);

            try
            {
                if (query.Rows.Count > 0)
                {
                    error.Success();
                    return new JsonResult(query);
                }
                else
                {
                    return new JsonResult("Not found");
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

        [Route("getAllServices")]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT * FROM tblServicio";

            DataTable table = new DataTable();
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
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
                return new JsonResult(table);
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("getAllFinishedAppointments")]
        [HttpGet]
        public JsonResult GetFinished(int idUser)
        {
            string query = @"SELECT * FROM tblServicio";

            DataTable table = new DataTable();
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
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
                return new JsonResult(table);
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("getPendingAppointments")]
        [HttpGet]
        public JsonResult GetPending(int idUser)
        {
            string query = @"SELECT * FROM tblServicio";

            DataTable table = new DataTable();
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
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
                return new JsonResult(table);
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
        /* Data access to register a service does not exist
        [Route("postService")]
        [HttpPost]
        public JsonResult Post(Service service)
        {
            // Query to insert the data needed
            bool query = models.RegisterService();

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

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
        */

        // Updates the information of the user. INCOMPLETE
        [Route("putService")]
        [HttpPut]
        public JsonResult Put(Service service)
        {
            string query = @"update tblServicio
                             set Tipo_Servicio = @service, FechaPromesa = @promesa
                             where ID_Servicio = @idService and ID_Mantenimiento = @idMantenimiento";

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
                        command.Parameters.AddWithValue("@idService", service.ID_Service);
                        command.Parameters.AddWithValue("@idMantenimiento", service.ID_Mantenimiento);
                        command.Parameters.AddWithValue("@service", service.Service_Type);
                        command.Parameters.AddWithValue("@promesa", service.FechaPromesa);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                error.Success();
                return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Service updated!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("deleteService")]
        [HttpDelete]
        public JsonResult Delete(int idService)
        {
            string query = "DELETE FROM tblServicio WHERE ID_Servicio = @idService";
            string sqlDataSource = (con.ReturnConnection().ConnectionString);

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idService", idService);

                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Service deleted!");
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
