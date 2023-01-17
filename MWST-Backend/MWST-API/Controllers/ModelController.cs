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

namespace MWST_API.Controllers
{
    [Route("api/Model")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public ModelController()
        {
        }

        [Route("getModels")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select Nombre_Modelo from tblModelo";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
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
                    }
                }
                if (table.Rows.Count > 0 && table != null)
                {
                    return new JsonResult(table);
                }
                else
                {
                    return new JsonResult("Nothing here");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }


        [Route("getModel")]
        [HttpGet]
        public JsonResult Get(int idModel)
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select Nombre_Modelo from tblModelo where ID_Modelo = @idModel";

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
                // Use the domain instead
                using (SqlConnection connection = new SqlConnection(sqlDataSource))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idModel", idModel);
                        command.ExecuteNonQuery();
                        reader = command.ExecuteReader();
                        table.Load(reader);
                    }
                }
                if (table.Rows.Count > 0 && table != null)
                {
                    return new JsonResult(table);
                }
                else
                {
                    return new JsonResult(table);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }

        //[Route("getModel")]
        //[HttpDelete]
        //public JsonResult Get(int idModel)
        //{
        //    bool query = models.CheckModel(idModel);

        //    try
        //    {
        //        if (query)
        //        {
        //            error.Success();
        //            return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Model has been deleted!");
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


        [Route("postModel")]
        [HttpPost]
        public JsonResult Post(Model model)
        {
            bool query = models.RegisterModelo(model.Name_Model, model.ID_Marca);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Modelo has been registered!");
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

        [Route("putModel")]
        [HttpPut]
        public JsonResult Put(Model model)
        {
            bool query = models.UpdateModelo(model.ID_Model, model.Name_Model, model.ID_Marca);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Model has been updated!");
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

        [Route("deleteModel")]
        [HttpDelete]
        public JsonResult Delete(int idModel)
        {
            bool query = models.DeleteModelo(idModel);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Model has been deleted!");
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
