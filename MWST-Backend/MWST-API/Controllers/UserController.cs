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
using Microsoft.AspNetCore.Identity;
using MWST_API.Models;

namespace MWST_API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public UserController()
        {
        }

        //Selects to get information
        [Route("getUser")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select Nombre, Apellido, Rol from tblUsuario";
            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = con.ReturnConnection().ConnectionString;
            SqlDataReader reader;

            // Use the domain instead
            try
            {
                error.Success();

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

                return new JsonResult($"{error.ErrorCode}: {error.ErrorMessage} \n\r" + table);
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
        [Route("registerUser")]
        [HttpPost]
        public JsonResult Post(User user)
        {
            string userRol = user.GetUserRol();

            // Query to insert the data needed
            bool query = models.RegisterAUser(user.Username, user.Password, user.Email, user.Name, user.Surname, user.Cedula, userRol, user.PhoneNumber, user.Cellphone);

            // New the connection string
            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "User has been registered!");
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

        // Updates the information of the user. INCOMPLETE
        [Route("putUser")]
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
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("deleteUser")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            // Used in BackOffice
            bool query = models.DeleteUser(id);

            // New the connection string
            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "User has been deleted!");
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
    }
}
