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
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public VehicleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("getVehicle")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select Matricula, VIN, Color from Vehiculo";

            DataTable table = new DataTable();
            // Check if does not return connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
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
                return new JsonResult(table);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }

        [Route("postVehicle")]
        [HttpPost]
        public JsonResult Post(Vehicle car)
        {
            bool query = models.RegisterUsersVehicle(car.Matricula, car.ID_User, car.ID_Marca, car.ID_Model, car.VIN, car.Color);

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
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Post Request.");
            }
        }

        [Route("putVehicle")]
        [HttpPut]
        public JsonResult Put(Vehicle car)
        {
            // Updating query. Change to stored procedure
            string query = @"Update Matricula, VIN, Color from Vehiculo 
                            set Matricula = @matricula, VIN = @vin, Color = @color
                            where ID_Vehicle = @idVehicle";

            DataTable table = new DataTable();
            // Check if does not return connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
                // Use the domain instead
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idVehicle", car.ID_Vehicle);
                        command.Parameters.AddWithValue("@matricula", car.Matricula);
                        command.Parameters.AddWithValue("@vin", car.VIN);
                        command.Parameters.AddWithValue("@color", car.Color);

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult(table);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Put Request.");
            }
        }

        [Route("deleteVehicle")]
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
