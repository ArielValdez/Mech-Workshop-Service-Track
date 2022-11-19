﻿using Microsoft.AspNetCore.Http;
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
    [Route("api/Maintenance")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public MantenimientoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("getMaintenance")]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Tipo_Mantenimiento from Mantenimiento";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
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
                return new JsonResult(table);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }

        [Route("getMaintenances")]
        [HttpGet]
        public JsonResult Get(Mantenimiento maintenance)
        {
            // Query to select the data needed
            string query = @"Tipo_Mantenimiento from Mantenimiento"; //Delete later, as this creates 2 queries
            bool validation = models.CheckMaintenance(maintenance.ID_Mantenimiento);

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
                if (validation)
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

        // Adds information into the database
        [Route("postMaintenance")]
        [HttpPost]
        public JsonResult Post(Mantenimiento maintenance)
        {
            // Query to insert the data needed
            bool query = models.RegisterMaintenance(maintenance.Tipo_Mantenimiento);

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

        // Updates the information of the user.
        [Route("putMaintenance")]
        [HttpPut]
        public JsonResult Put(Mantenimiento maintenance)
        {
            // Create, later, a data access for and to update
            // Query to update the information of the user

            string query = @"update Mantenimiento
                             set Tipo_Mantenimiento = @tipoMantenimiento
                             where ID_Mantenimiento = @idMantenimiento";

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
                        command.Parameters.AddWithValue("@idMantenimiento", maintenance.ID_Mantenimiento);
                        command.Parameters.AddWithValue("@tipoMantenimiento", maintenance.Tipo_Mantenimiento);

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                return new JsonResult("{0}: Successful Update", maintenance.ID_Mantenimiento);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Put Request.");
            }
        }

        [Route("deleteMaintenance")]
        [HttpDelete]
        public JsonResult Delete(Mantenimiento maintenance)
        {
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
