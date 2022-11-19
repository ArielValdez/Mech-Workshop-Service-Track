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
    [Route("api/Service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public ServiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("getService")]
        [HttpGet]
        public JsonResult Get(Service service)
        {
            // Query to select the data needed. Change to stored procedures
            bool query = models.CheckService(service.ID_Service);

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
                            table.Load(reader); // Check the use of this table later
                            reader.Close();
                            connection.Close();
                        }
                    }
                    return new JsonResult(table);
                }
                else
                {
                    return new JsonResult("Incorrect username or password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
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
            // Create, later, a data access for and to update
            // Query to update the information of the user

            // This only updates the table PerfilUsuario
            string query = @"update Servicio
                             set Tipo_Servicio = @service, FechaPromesa = @promesa
                             where ID_Servicio = @idService and ID_Mantenimiento = @idMantenimiento";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
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

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                return new JsonResult("{0}: Successful Update", service.ID_Service);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Put Request.");
            }
        }

        [Route("deleteService")]
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
