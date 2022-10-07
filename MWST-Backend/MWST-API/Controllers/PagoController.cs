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
        private readonly IConfiguration _configuration;
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public PagoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Selects to get information
        [HttpGet]
        public JsonResult Get()
        {
            // Query to select the data needed
            // Use domain
            string query = @"select Forma_Pago, Pago_Servicio, Tipo_Servicio, FechaPromesa" +
                            "from Pago inner join Servicio on Servicio.ID_Servicio = Pago.ID_Servicio" +
                            "where ID_Pago = @idPayment";

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
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }

        // Adds information into the database
        // There is nothing to Register a Receipt. Add later
        /*
        [HttpPost]
        public JsonResult Post(Pago payment)
        {
            // Query to insert the data needed
            bool query = ;

            DataTable table = new DataTable();
            // New the connection string
            string sqlDataSource = _configuration.GetConnectionString(con.ReturnConnection().ConnectionString);
            SqlDataReader reader;

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
        */
    }
}
