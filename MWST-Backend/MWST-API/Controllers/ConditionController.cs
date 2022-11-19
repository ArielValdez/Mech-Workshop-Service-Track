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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MWST_API.Models;

namespace MWST_API.Controllers
{
    [Route("api/Condition")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public ConditionController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [Route("getCondition")]
        [HttpGet]
        public JsonResult Get(Condition condition)
        {
            // Query to select the data needed. Change to stored procedures
            bool query = models.CheckCondition(condition.ID_Estado);

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
                    return new JsonResult("Nothing to see");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }

        // Create a method to register conditions
        [Route("postCondition")]
        [HttpPost]
        public JsonResult Post(Condition condition)
        {
            // Query to insert the data needed
            bool query = models.RegisterCondition();

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
                return new JsonResult("Not implemented yet.");
            }
        }

        // Upload an image to the database
        // Check later, as it needs a proper way to be handled
        [Route("saveImage")]
        [HttpPost]
        public JsonResult SaveFile([FromBody] FileModel file)
        {
            try
            {

                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                file.FileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + file.FileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(file.FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Excetion Type: {0}", e.GetType());
                Console.WriteLine("Exception Message: {0}", e.Message);
                return new JsonResult("searching car.png");
            }
        }

        [Route("putCondition")]
        [HttpPut]
        public JsonResult Put(Condition condition)
        {
            // Create, later, a data access for and to update
            // Query to update the information of the user

            // This only updates the table PerfilUsuario
            string query = @"update Estado
                             set Nombre_Estado = @nombreEstado, Descripcion_Estado = @descripcion, Imagen = @imagen
                             where ID_Estado = @idEstado and ID_Servicio = @idServicio";

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
                        command.Parameters.AddWithValue("@idEstado", condition.ID_Estado);
                        command.Parameters.AddWithValue("@idServicio", condition.ID_Service);
                        command.Parameters.AddWithValue("@nombreEstado", condition.Nombre_Estado);
                        command.Parameters.AddWithValue("@descripcion", condition.Descripcion);
                        command.Parameters.AddWithValue("@imagen", condition.Imagen);

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                return new JsonResult("{0}: Successful Update", condition.ID_Estado);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Put Request.");
            }
        }

        [Route("deleteCondition")]
        [HttpDelete]
        public JsonResult deleteCondition()
        {
            return new JsonResult("Not implemented yet.");
        }
    }
}
