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
    [Route("api/Piece")]
    [ApiController]
    public class PiezaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public PiezaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(Pieza parts)
        {
            // Query to select the data needed. Change to stored procedures
            bool query = models.CheckParts(parts.ID_Pago); //Check data access and Pieza model later

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
                        table.Load(reader); // Check the use of this table later
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult(table);
            }
            else
            {
                return new JsonResult("Incorrect username or password.");
            }
        }

        // Adds information into the database
        /* RegisterPart data access does not exist yet
        [HttpPost]
        public JsonResult Post(User user)
        {
            string userRol = user.GetUserRol();

            // Query to insert the data needed
            bool query = models.RegisterPart();

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
        [HttpPut]
        public JsonResult Put(Pieza part)
        {
            // Create, later, a data access for and to update
            // Query to update the information of the user

            string query = @"update Piezas
                             set Nombre_Pieza = @pieza, Descripcion_Pieza = @descripcion, Precio_Pieza = @precio, Cantidad = @cantidad,
                             where ID_Pieza = @idPieza and ID_Pago = @pago";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            // Use the domain instead
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPieza", part.ID_Pieza);
                    command.Parameters.AddWithValue("@idPieza", part.ID_Pago);
                    command.Parameters.AddWithValue("@pieza", part.Nombre_Pieza);
                    command.Parameters.AddWithValue("@descripcion", part.Descripcion_Pieza);
                    command.Parameters.AddWithValue("@cantidad", part.Cantidad);

                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            // Check for security
            return new JsonResult("{0}: Successful Update", part.ID_Pieza);
        }

        // Make later, to delete
        [HttpDelete]
        public JsonResult Delete()
        {
            return new JsonResult("Not implemented yet.");
        }
    }
}
