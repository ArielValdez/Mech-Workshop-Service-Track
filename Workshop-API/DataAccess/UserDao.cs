using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        /* check and validate the return value of all the methods */
        /* create stored procedures later */

        #region Accessing
        // This method is called when the user enters their data for authentication
        public bool Login(string username, string password)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users credential
                        command.CommandText = "select * from PerfilUsuario where Username=@username and Password=@password";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.CommandType = CommandType.Text;

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Rollback should be added
                throw e;
            }
        }

        public bool UserHistory(int idUser, int idPay)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "select Historial.Fecha";
                        command.Parameters.AddWithValue();
                        command.Parameters.AddWithValue();
                        command.CommandType = CommandType.Text;

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Rollback should be added
                throw e;
            }
        }
        #endregion

        #region Registering
        // This method is used when the user registers into the database
        // Rol should be stored as an enum
        public bool RegisterUser(string username, string password, string email, string nombre,
                                 string apellido, string cedula, string rol,
                                 string telefono, string celular)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        //Replace this part with stored procedures
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into PerfilUsuario(Username, Password, Telefono, Celular, Email, FechaCreacion)" +
                                              "values(@username, @password, @telefono, @celular, @email, @fechaCreacion)";

                        command.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                        command.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                        command.Parameters.Add("@telefono", SqlDbType.Char, 13).Value = telefono;
                        command.Parameters.Add("@celular", SqlDbType.Char, 13).Value = celular;
                        command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                        command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);

                        //Inserting values into the database, table Usuario
                        command.CommandText = "insert into Usuario(Nombre, Apellido, Cedula, Rol)" +
                                              "values(@nombre, @apellido, @cedula, @rol)";
                       
                        command.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                        command.Parameters.Add("@apellido", SqlDbType.VarChar, 30).Value = apellido;
                        command.Parameters.Add("@cedula", SqlDbType.Char, 11).Value = cedula;
                        command.Parameters.Add("@celular", SqlDbType.VarChar, 13).Value = rol; // Replace this with an enum value

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }

        // This method is used to register the vehicle of an user, after they register as an user
        public bool RegisterVehicle(string matricula, int idUsuario, int idMarca, int idModelo, string vin, string color)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Vehiculo(Matricula, ID_Usuario, ID_Marca, ID_Modelo, VIN, Color)" +
                                              "values(@matricula, @idUsuario, @idMarca, @idModelo, @vin, @color)";

                        if (true)
                        {
                            /* The FKs should select the table they come from to instert into this table if they exist in the
                            database, otherwise, a new row should be created in their respective tables */
                        }
                        else
                        {
                            // Put all the insertions here
                        }

                        command.Parameters.Add("@matricula", SqlDbType.Char, 7).Value = matricula;
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario; // FK of Usuario
                        command.Parameters.Add("@idMarca", SqlDbType.Int).Value = idMarca; // FK of Marca
                        command.Parameters.Add("@idModelo", SqlDbType.Int).Value = idModelo; // FK of Modelo
                        command.Parameters.Add("@vin", SqlDbType.Char, 17).Value = vin;
                        command.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = color;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }
        #endregion
        public void Maintenance(string TipoMantenimiento)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        //Replace this part with stored procedures
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Mantenimiento(Tipo_Mantenimiento) values(@tipoMantenimiento)";

                        command.Parameters.Add("@tipoMantenimiento", SqlDbType.VarChar, 30).Value = TipoMantenimiento;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }

        public void Service()
        {

        }

        public void Condition()
        {

        }

        #region Marca&Modelo
        // inserts values into their respective tables
        private void Marca(string nombreMarca)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        //Replace this part with stored procedures
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Marca(Nombre) values(@nombreMarca)";

                        command.Parameters.Add("@nombreMarca", SqlDbType.Char, 18).Value = nombreMarca;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }

        private void Modelo(string nombreModelo, int idMarca)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        //Replace this part with stored procedures
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Marca(Nombre_Modelo, ID_Marca) values(@nombreModelo, @fkMarca)";

                        command.Parameters.Add("@nombreModelo", SqlDbType.Char, 18).Value = nombreModelo;
                        command.Parameters.Add("@fkMarca", SqlDbType.Int).Value = idMarca; // FK of Marca

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }
        #endregion
        #region Provincia&Municipio

        // Stores provincia of the workshop
        public void Provincia(string nameProvincia, string description)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        //Replace this part with stored procedures
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Provincia(Provincia, Descripcion) values(@provincia, @descripcion)";

                        command.Parameters.Add("@provincia", SqlDbType.VarChar, 30).Value = nameProvincia;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }

        // Stores municipio of the workshop
        public void Municipio(string nameMunicipio, string description, int idProvincia)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        //Replace this part with stored procedures
                        command.Connection = connection;

                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Provincia(Municipio, Descripcion, ID_Provincia)" + 
                                              "values(@municipio, @descripcion, @idProvincia)";

                        command.Parameters.Add("@municipio", SqlDbType.VarChar, 70).Value = nameMunicipio;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;
                        command.Parameters.Add("@idProvincia", SqlDbType.Int).Value = idProvincia;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // In case of sql malfunctioning, add a rollback here
                throw e;
            }
        }
        #endregion
    }
}
