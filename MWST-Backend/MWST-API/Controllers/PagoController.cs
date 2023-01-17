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
    [Route("api/Payment")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public PagoController(IConfiguration configuration)
        {
        }
        #region Payment
        //Selects to get information
        [Route("getPagos")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed
            // Use domain
            string query = @"select Forma_Pago, Pago_Servicio, Tipo_Servicio, FechaPromesa" +
                            "from tblPago inner join Servicio on Servicio.ID_Servicio = Pago.ID_Servicio";

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
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult(table);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }

        [Route("getPago{id}")]
        [HttpGet]
        public JsonResult Get(int idPayment)
        {
            // Query to select the data needed. Change to stored procedures
            DataTable query = models.CheckParts(idPayment);

            try
            {
                if (query.Rows.Count > 0)
                {
                    error.Success();
                    return new JsonResult(query);
                }
                else
                {
                    return new JsonResult("Not found");
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
        [Route("postPago")]
        [HttpPost]
        public JsonResult Post(Pago payment)
        {
            // Query to insert the data needed
            bool query = models.RegisterReceipt(payment.FormaPago(), payment.Pago_Servicio, payment.ID_Vehicle, payment.ID_Service, payment.ID_Workshop, payment.FechaInicio, payment.FechaPromesa, payment.FechaEntrega);

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = (con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Post Request.");
            }
        }

        /* This needs to update both Detalle and Pago tables
        [Route("putPago")]
        [HttpPut]
        public JsonResult Put(User user)
        {
            // Create, later, a data access for and to update
            // Query to update the information of the user

            // This only updates the table PerfilUsuario
            string query = @"update Pago
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
        */

        [Route("deletePago")]
        [HttpDelete]
        public JsonResult Delete()
        {
            //string query = @"select Forma_Pago, Pago_Servicio, Tipo_Servicio, FechaPromesa" +
            //                "from Pago inner join Servicio on Servicio.ID_Servicio = Pago.ID_Servicio" +
            //                "where ID_Pago = @idPayment";

            //DataTable table = new DataTable();
            //// New the connection string
            //string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            //SqlDataReader reader;

            // A payment not its detail should not be deleted
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Post Request.");
            }
        }
        #endregion

        #region CreditCard
        [Route("getAllCards")]
        [HttpGet]
        public JsonResult GetCreditCard(int idUser)
        {
            string query = @"SELECT * tblCreditCards WHERE ID_Usuario = @idUser";

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
                        command.Parameters.AddWithValue("@idUser", idUser);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult("Credit Card Deleted");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("createCreditCard")]
        [HttpPost]
        public JsonResult CreateCredit(CreditCard cc)
        {
            string query = @"INSERT INTO tblCreditCards(Numeros, FechaExpiracion, Nombre, ID_Usuario) 
                             VALUES(@numbers, @expiration, @cvv, @name, @idUser)";

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
                        command.Parameters.AddWithValue("@idUser", cc.IdUser);
                        command.Parameters.AddWithValue("@numbers", cc.Numbers);
                        command.Parameters.AddWithValue("@expiracion", cc.ExpirationDate.ToString("MM-yyyy"));
                        command.Parameters.AddWithValue("@cvv", cc.CVV);
                        command.Parameters.AddWithValue("@name", cc.Name);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult("Card registered!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("editCards")]
        [HttpPut]
        public JsonResult EditCard(CreditCard cc)
        {
            string query = @"update tblCreditCards
                             set Numeros = @numbers, FechaExpiracion = @expiracion,
                             CVV = @cvv, Nombre = @name where ID_Card = @idCard and ID_Usuario = @idUser";

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
                        command.Parameters.AddWithValue("@idCard", cc.ID);
                        command.Parameters.AddWithValue("@idUser", cc.IdUser);
                        command.Parameters.AddWithValue("@numbers", cc.Numbers);
                        command.Parameters.AddWithValue("@expiracion", cc.ExpirationDate.ToString("MM-yyyy"));
                        command.Parameters.AddWithValue("@cvv", cc.CVV);
                        command.Parameters.AddWithValue("@name", cc.Name);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult("Card updated!");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("deleteCard")]
        [HttpGet]
        public JsonResult DeleteCreditCard(int idCard)
        {
            string query = @"DELETE FROM tblCreditCards WHERE ID_Credit = @idCard";

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
                        command.Parameters.AddWithValue("@idCard", idCard);

                        command.ExecuteNonQuery();

                        reader = command.ExecuteReader();
                        table.Load(reader);
                        reader.Close();
                        connection.Close();
                    }
                }
                return new JsonResult("Credit Card Deleted");
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }
        #endregion
    }
}
