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

namespace MWST_API.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public PagoController(IConfiguration configuration)
        {
        }

        //Selects to get information
        [Route("getPago")]
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed
            // Use domain
            string query = @"select Forma_Pago, Pago_Servicio, Tipo_Servicio, FechaPromesa" +
                            "from tblPago inner join Servicio on Servicio.ID_Servicio = Pago.ID_Servicio" +
                            "where ID_Pago = @idPayment";

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
    }
}
