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
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public UserController()
        {
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

        //[Route("getUser{id}")]
        //[HttpDelete]
        //public JsonResult Get(int idUser)
        //{
        //    DataTable query = models.CheckUser(idUser);

        //    try
        //    {
        //        if (query != null && query.Rows.Count > 0)
        //        {
        //            error.Success();
        //            return new JsonResult(query);
        //        }
        //        else
        //        {
        //            return new JsonResult("Not all fields have been filled");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        error.ErrorCode = "400";
        //        error.ErrorMessage = "Something went wrong";
        //        error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
        //        return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
        //    }
        //}


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
