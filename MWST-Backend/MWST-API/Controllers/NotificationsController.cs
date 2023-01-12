using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Domain;
using System.Net.Mail;
using System.Data.SqlClient;

namespace MWST_API.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public IActionResult Index()
        {
            return View();
        }

        [Route("sendEmailConfirmation")]
        [HttpGet]
        public JsonResult EmailConfirmation(int idUser)
        {
            error.Success();
            string query = "SELECT email FROM tblUsuario WHERE ID_Usuario = @idUser";
            string email = string.Empty;

            #region Fetching email if exists in database
            try
            {
                using (SqlConnection conn = new SqlConnection(con.ReturnConnection().ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.CommandType = System.Data.CommandType.Text;
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            email = (string)reader["email"];
                        }
                        else
                        {
                            return new JsonResult("No Email found");
                        }

                        reader.Close();
                        conn.Close();
                    }

                }

                return new JsonResult(error.ErrorCode + " " + error.ErrorMessage);
            }
            catch (Exception ex)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = ex.Message;
                return new JsonResult(error.ErrorCode + " " + error.ErrorMessage + "\r\n" + error.Exception);
            }
            #endregion

            #region Email confirmation

            #endregion

            return new JsonResult(error.ErrorCode + " " + error.ErrorMessage);
        }

        // Sends email. Does not work
        [Route("sendEmailNotification")]
        [HttpGet]
        public JsonResult EmailNotification(int idUser)
        {
            error.Success();
            string query = "SELECT email FROM tblUsuario WHERE ID_Usuario = @idUser";
            string email = string.Empty;

            #region Fetching email if exists in database
            try
            {
                using (SqlConnection conn = new SqlConnection(con.ReturnConnection().ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@idUser", idUser);
                        command.CommandType = System.Data.CommandType.Text;
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            email = (string)reader["email"];
                        }
                        else
                        {
                            return new JsonResult("No Email found");
                        }

                        reader.Close();
                        conn.Close();
                    }

                }

                return new JsonResult(error.ErrorCode + " " + error.ErrorMessage);
            }
            catch (Exception ex)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = ex.Message;
                return new JsonResult(error.ErrorCode + " " + error.ErrorMessage + "\r\n" + error.Exception);
            }
            #endregion

            #region Send notification to the new user
            using (MailMessage mail = new MailMessage())
            {
                if (!string.IsNullOrEmpty(email))
                {
                    mail.To.Add(email);
                    mail.Subject = "New user";
                    mail.Body = "<h1>You have created a new account on Mech Workshop Service Track</h1>";
                    mail.IsBodyHtml = true;
                }
                else
                {
                    return new JsonResult("Email does not exist!");
                }
            }
            #endregion

            return new JsonResult(error.ErrorCode + " " + error.ErrorMessage);
        }

        [Route("sendConditionNotification")]
        [HttpGet]
        public void ConditionNotification()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
