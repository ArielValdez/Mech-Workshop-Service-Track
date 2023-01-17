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
    [Route("api/Workshop")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public WorkshopController()
        {
            
        }

        [Route("getAllWorkshops")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"SELECT * FROM tblTaller_Mecanico";

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
                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
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


        [Route("getWorkshop")]
        [HttpGet]
        public JsonResult Get(int idWorkshop)
        {
            // Query to select the data needed. Change to stored procedures
            DataTable query = models.CheckWorkshop(idWorkshop);

            try
            {
                if (query != null && query.Rows.Count > 0)
                {
                    error.Success();
                    return new JsonResult(query);
                }
                else
                {
                    return new JsonResult("Workshop not found!");
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

        // Adds information into the database
        [Route("postWorkshop")]
        [HttpPost]
        public JsonResult Post(WorkShop workShop)
        {
            string query = @"insert into tblTaller_Mecanico(Nombre_Taller, Encargado, ID_Provincia, Horario_Abierto, Horario_Cierre, ID_Usuario)
                             values (@taller, @encarcago, @idProvincia, @abierto, @cierre, @idUsuario)";

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
                        command.Parameters.AddWithValue("@taller", workShop.Name_WorkShop);
                        command.Parameters.AddWithValue("@encarcago", string.Empty); // Check later
                        command.Parameters.AddWithValue("@idProvincia", workShop.Location);
                        command.Parameters.AddWithValue("@abierto", DateTime.Now);
                        command.Parameters.AddWithValue("@cierre", DateTime.Now.AddHours(8));
                        command.Parameters.AddWithValue("@idUsuario", 1);

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                error.Success();
                return new JsonResult("Workshop registered!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("putWorkshop")]
        [HttpPut]
        public JsonResult Put(WorkShop workShop)
        {
            string query = @"update tblTaller_Mecanico
                             set Nombre_Taller = @taller, Encargado = @encarcago
                             where ID_Taller = @idTaller";

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
                        command.Parameters.AddWithValue("@idTaller", workShop.ID_WorkShop);
                        command.Parameters.AddWithValue("@taller", workShop.Name_WorkShop);
                        command.Parameters.AddWithValue("@encargado", string.Empty);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult("Workshop updated!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("deleteWorkshop")]
        [HttpDelete]
        public JsonResult Delete(int idWorkshop)
        {
            string query = @"Delete from tblTaller_Mecanico
                             where ID_Taller = @idTaller";

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
                        command.Parameters.AddWithValue("@idTaller", idWorkshop);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                // Check for security
                error.Success();
                return new JsonResult("Workshop deleted!");
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
