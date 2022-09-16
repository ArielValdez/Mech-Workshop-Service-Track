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

        // This should make show a user history
        // Check later
        public bool UserHistory()
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
                        command.CommandText = "select Historial.Fecha, Usuario, Pago" +
                                              "from ((History inner join Usuario on Historial.ID_Usuario = Usuario.ID_Usuario)" +
                                              "inner join Pago on History.ID_Pago = Pago.ID_Pago)";
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

        public bool CheckVehicle(string matricula)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users vehicle
                        command.CommandText = "select Matricula, Usuario.Nombre, Usuario.Apellido, Nombre_Marca, Nombre_Modelo, VIN, Color" +
                                              "from Vehiculo v inner join Usuario u on u.ID_Usuario = v.ID_Usuario" +
                                              "inner join Marca m on m.ID_Marca = v.ID_Marca" +
                                              "inner join Modelo mo on mo.ID_Modelo = v.ID_Modelo" +
                                              "where Matricula = @matricula";

                        command.Parameters.AddWithValue("@matricula", matricula);

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

        public bool CheckMaintenance(string tipoMantenimiento)
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
                        command.CommandText = "select Tipo_Mantenimiento from Mantenimiento where Tipo_Mantenimiento = @tipoMantenimiento";
                        command.Parameters.AddWithValue("@tipoMantenimiento", tipoMantenimiento);
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

        public bool Service(string tipoServicio, int idMantenimiento)
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
                        command.CommandText = "select Tipo_Servicio, Tipo_mantenimiento, Fecha_Promesa" +
                                              "from Servicio inner join Mantenimiento on Mantenimiento.ID_Mantenimiento = Service.ID_Mantenimiento" +
                                              "where ID_Mantenimiento = @idMantenimiento and Tipo_Servicio = @tipoServicio";
                        
                        command.Parameters.AddWithValue("@idMantenimiento", idMantenimiento);
                        command.Parameters.AddWithValue("@tipoServicio", tipoServicio);
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

        public bool Condition(string conditionName, int idService)
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
                        command.CommandText = "select Nombre_Estado, Descripcion_Estado, Imagen_Estado, Tipo_Servicio" +
                                              "from Estado inner join Servicio on Servicio.ID_Servicio = Estado.ID_Servicio" +
                                              "where Nombre_Estado = @conditionName and ID_Servicio = @idServicio";
                        
                        command.Parameters.AddWithValue("@conditionName", conditionName);
                        command.Parameters.AddWithValue("@idService", idService);

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

        public bool CheckPayment(int idServicio) { //Detail might need to call Detail
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "select Forma_Pago, Pago_Servicio, Tipo_Servicio, FechaPromesa" +
                                              "from Pago inner join Servicio on Servicio.ID_Servicio = Pago.ID_Servicio" +
                                              "where ID_Servicio = @idServicio";
                        
                        command.Parameters.AddWithValue("@idService", idService);

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

        public bool CheckDetail() {
            //
        }

        public bool CheckParts(int idPayment) { //check later
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "select Nombre_Pieza, Descripcion_Pieza, Precio_Pieza, Cantidad, ID_Pago" +
                                              "from Pieza inner join Pago on Pago.ID_Pago = Pieza.ID_Pago" +
                                              "where ID_Pago = @idPayment";
                        
                        command.Parameters.AddWithValue("@idPayment", idPayment);

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

        public bool CheckWorkshop (int idUsuario) {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "select Nombre_Taller, Provincia, Encargado" +
                                              "from Taller_Mecanico t inner join Provincia p on p.ID_Provincia = t.ID_Provincia" +
                                              "inner join Usuario u on u.ID_Usuario = t.ID_Usuario" +
                                              "where ID_Usuario = @idUsuario";
                        
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

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
                        if (!reader.HasRows)
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

                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
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

        public bool RegisterMaintenance(string TipoMantenimiento)
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

                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
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

        #region Marca&Modelo
        // inserts values into their respective tables
        private bool RegisterMarca(string nombreMarca)
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


                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
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

        private bool RegisterModelo(string nombreModelo, int idMarca)
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

                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
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
        #region Provincia&Municipio
        // Stores provincia of the workshop
        public bool Provincia(string nameProvincia, string description)
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

                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
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

        // Stores municipio of the workshop
        public bool Municipio(string nameMunicipio, string description, int idProvincia)
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

                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
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

        /* 
        if(steal()) {
            IP = this.Location(tuCasa);
            Exponer(your(IP));
            Borrar(Mech Workshop Service Track.Code);
            Borrar(MWST);
            Explotar(this.PC => tuPC);
        }
        else {
            do(Nothing);
            return;
        }
        */
    }
}
