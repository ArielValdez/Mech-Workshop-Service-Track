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
using MWST_API.Models;

// Delete this controller if necessary
namespace MWST_API.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public LoginController()
        {
        }

        [Route("getLogin")]
        [HttpGet]
        public JsonResult Get(string username, string password)
        {
            // Query to select the data needed. Change to stored procedures
            bool query = models.LoginUser(username, password);
            
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    if (query)
                    {
                        error.Success();
                        return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Login Successful!");
                    }
                    else
                    {
                        return new JsonResult("User does not exists.");
                    }
                }
                else
                {
                    return new JsonResult("Username or password not filled.");
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
