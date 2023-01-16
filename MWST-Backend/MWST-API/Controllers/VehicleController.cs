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
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public VehicleController()
        {

        }

        [Route("getVehicles")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed. Change to stored procedures
            string query = @"select Matricula, VIN, Color from tblVehiculo";

            DataTable table = new DataTable();
            // Check if does not return connection string
            string sqlDataSource = con.ReturnConnection().ConnectionString;
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
                        reader.Close();
                        connection.Close();
                    }
                }
                error.Success();
                return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Vehicle get!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("getVehicle")]
        [HttpDelete]
        public JsonResult Get(string matricula)
        {
            bool query = models.CheckVehicle(matricula);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Vehicle has been deleted!");
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


        [Route("postVehicle")]
        [HttpPost]
        public JsonResult Post(Vehicle car)
        {
            bool query = models.RegisterUsersVehicle(car.Matricula, car.ID_User, car.ID_Marca, car.ID_Model, car.VIN, car.Color);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Vehicle has been registered!");
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

        [Route("putVehicle")]
        [HttpPut]
        public JsonResult Put(Vehicle car)
        {
            bool query = models.UpdateVehicle(car.ID_Vehicle, car.Matricula, car.ID_User, car.ID_Marca, car.ID_Model, car.VIN, car.Color);
            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Vehicle has been updated!");
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

        [Route("deleteVehicle")]
        [HttpDelete]
        public JsonResult Delete(int idCar)
        {
            bool query = models.DeleteVehicle(idCar);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Vehicle has been deleted!");
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
