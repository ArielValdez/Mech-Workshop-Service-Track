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
    [Route("api/Condition")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public ConditionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(Condition condition)
        {
            // Query to select the data needed. Change to stored procedures
            bool query = models.CheckCondition(condition.ID_Estado);

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
                return new JsonResult("Nothing to see");
            }
        }

        // Create a method to register conditions
        /*
        [HttpPost]
        public JsonResult Post(Condition condition)
        {
            // Query to insert the data needed
            bool query = models.Re

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
        public JsonResult Put(Condition condition, Service service)
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
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idEstado", condition.ID_Estado);
                    command.Parameters.AddWithValue("@idServicio", service.ID_Service);
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
    }
}