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
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Selects to get information
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select Nombre, Apellido, Cedula, Rol from Usuario";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            // Use the domain instead
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }

        // Adds information into the database
        [HttpPost]
        public JsonResult Post(User user)
        {
            string userRol = user.GetUserRol();

            // Query to insert the data needed
            bool query = models.RegisterAUser(user.Username, user.Password, user.Email, user.Name, user.Surname, user.Cedula, userRol, user.PhoneNumber, user.Cellphone);

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

        // Updates the information of the user. INCOMPLETE
        [HttpPut]
        public JsonResult Put(User user)
        {
            // Create, later, a data access for and to update
            // Query to update the information of the user

            // This only updates the table PerfilUsuario
            string query = @"update PerfilUsuario
                             set Username = @username, Password = @password, Telefono = @phoneNumber, Celular = @cellphone,
                             where ID_Usuario = @idUsuario";

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
                    command.Parameters.AddWithValue("@idUsuario", user.ID_User);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@cellphone", user.Cellphone);
                    
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            // Check for security
            return new JsonResult("{0}: Successful Update", user.ID_User);
        }
    }
}
