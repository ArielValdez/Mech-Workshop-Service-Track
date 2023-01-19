using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using MWST_API.Models;
using Microsoft.Extensions.Logging;

namespace MWST_API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UserController> _logger;

        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public UserController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<UserController> logger
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
        }

        //Selects to get information
        [Route("getUsersTester")]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                error.Success();
                DataTable table = models.Test();

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

        [Route("getUser")]
        [HttpGet]
        public JsonResult Get(string email, string password)
        {
            string query = @"select * from tblUsuario where Email=@email and uPassword=@password";

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
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
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

        [Route("isEmailTaken")]
        [HttpGet]
        public JsonResult Get(string email)
        {
            string query = @"select * from tblUsuario where Email=@email";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;
            bool isTaken = false;

            // Use the domain instead
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }

                if (table.Rows.Count > 0)
                {
                    isTaken = true;
                }

                error.Success();
                return new JsonResult(isTaken);
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
                    #region Email confirmation
                    //var result = await _userManager.CreateAsync(user, user.Password);

                    //if (result.Succeeded)
                    //{
                    //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    //    var confirmationLink = Url.Action("ConfirmationEmail", "User", new {userID = user.ID_User, token = token }, Request.Scheme);

                    //    _logger.Log(LogLevel.Warning, confirmationLink);

                    //    if (_signInManager.IsSignedIn(User) && User.IsInRole("O"))
                    //    {
                    //        RedirectToAction("User", "Owner");
                    //    }
                    //}
                    #endregion
                    return new JsonResult("User has been registered!");
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
            string role = user.GetUserRol();

            bool query = models.UpdateUser(user.ID_User, user.Username, user.Password, user.Email, user.Name, user.Surname, user.Cedula, role, user.PhoneNumber, user.Cellphone);

            // Use the domain instead
            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "User has been updated!");
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

        [Route("changePassword")]
        [HttpPut]
        public JsonResult ChangePassword(string email, string newPassword)
        {
            string query = @"UPDATE tblUsuario
                             set uPassword = @newPassword WHERE Email = @email";

            string sqlDataSource = (con.ReturnConnection().ConnectionString);

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newPassword", newPassword);
                        command.Parameters.AddWithValue("@email", email);

                        int affectedUser = command.ExecuteNonQuery();

                        if (affectedUser > 0)
                        {
                            return new JsonResult("Password has been changed!");
                        }
                        else
                        {
                            return new JsonResult("Password cannot be changed or user could not be found");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\r\n" + "  Message: " + e.Message;
                return new JsonResult($"{ error.ErrorMessage }: {error.ErrorMessage}\r\n{error.Exception}");
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
