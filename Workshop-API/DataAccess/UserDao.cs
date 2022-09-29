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

        // This should show a user history
        public bool UserHistory(int idUser, int idHistory)
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
                        command.CommandText = "select Nombre, Apellido, Cedula, Forma_Pago, Pago_Servicio" +
                                              "from Historial h inner join Usuario u on u.ID_Usuario = h.ID_Usuario" +
                                              "inner join Pago p on p.ID_Pago = h.ID_Pago)" +
                                              "where ID_Usuario = @idUsuario and ID_Historial = @idHistory";

                        command.Parameters.AddWithValue("@idUsuario", idUser);
                        command.Parameters.AddWithValue("@idHistory", idHistory);

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

        public bool CheckMaintenance(int idMaintenance)
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
                        command.CommandText = "select Tipo_Mantenimiento from Mantenimiento where ID_Mantenimiento = @idMaintenance";
                        command.Parameters.AddWithValue("@idMaintenance", idMaintenance);
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

        public bool Service(int idService)
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
                                              "from Servicio inner join Estado on Estado.ID_Estado = Servicio.ID_Estado" +
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

        public bool Condition(int idCondition)
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
                                              "ID_Estado = @idCondition";
                        
                        command.Parameters.AddWithValue("@idCondition", idCondition);

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

        public bool CheckPayment(int idPayment) {
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

        public bool CheckDetail(int idPayment) {
            //
            return false;
        }

        public bool CheckParts(int idParts) {
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
                                              "where ID_Pieza = @idParts";
                        
                        command.Parameters.AddWithValue("@idParts", idParts);

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

        public bool CheckWorkshop (int idWorkshop) {
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
                                              "where ID_Taller = @idWorkshop";
                        
                        command.Parameters.AddWithValue("@idWorkshop", idWorkshop);

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
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
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
                        if (!reader.HasRows) //Does not exist
                        {
                            transaction.Commit();
                            return true;
                        }
                        else //Exists
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        // This method is used to register the vehicle of an user, after they register as an user
        public bool RegisterVehicle(string matricula, int idUsuario, int idMarca, int idModelo, string vin, string color)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = "insert into Vehiculo(Matricula, ID_Usuario, ID_Marca, ID_Modelo, VIN, Color)" +
                                          "values(@matricula, @idUsuario, @idMarca, @idModelo, @vin, @color)";

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
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        //This should be hidden from the common user. This adds maintenances
        public bool RegisterMaintenance(string TipoMantenimiento)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = "insert into Mantenimiento(Tipo_Mantenimiento) values(@tipoMantenimiento)";

                        command.Parameters.Add("@tipoMantenimiento", SqlDbType.VarChar, 30).Value = TipoMantenimiento;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();
                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        // The users history should be registered automatically
        public bool RegisterHistory(int idUsuario, int idPago, DateTime fecha) {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        //Inserting values into the database, table PerfilUsuario
                        command.CommandText = "insert into Historial(ID_Usuario, ID_Pago, Fecha) values(@idUsuario, @idPago, @fecha)";

                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        command.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;
                        command.Parameters.Add("@fecha", SqlDbType.DateTime2).Value = fecha;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();
                        //The part does not exist in the database, and registers it successfully
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        //This adds the receipt (both the "Pago" and "Detalle"). Not visible for the user to register
        public bool RegisterReceipt(string way2Pay, double payService, int idVehicle, int idService, int idWorkshop, DateTime fechaInicio, DateTime fechaPromesa, DateTime fechaEntrega) {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;

                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        //Inserting values into the database, table Detalle
                        command.CommandText = "insert into Detalle(Pago_Servicio, ID_Vehiculo, ID_Taller, FechaInicio, FechaPromesa, FechaEntrega)" +
                                          "values(@payService, @idVehicle, @idService, @fechaInicio, @fechaPromesa, @fechaEntrega)";

                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService;
                        command.Parameters.Add("@idVehicle", SqlDbType.Int).Value = idVehicle;
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        //Check these values later
                        command.Parameters.Add("@fechaInicio", SqlDbType.DateTime2).Value = fechaInicio;
                        command.Parameters.Add("@fechaPromesa", SqlDbType.DateTime2).Value = fechaPromesa;
                        command.Parameters.Add("@fechaEntrega", SqlDbType.DateTime2).Value = fechaEntrega;

                        //Inserting data into "Pago"
                        command.CommandText = "insert into Pago(Forma_Pago, Pago_Servicio, ID_Servicio)" +
                                            "values(@way2Pay, @payService, @idService)";

                        // "Forma_Pago" (way2Pay) should store enums (Credito, Debito)
                        command.Parameters.Add("@way2Pay", SqlDbType.VarChar, 25).Value = way2Pay; //Forma_Pago
                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService; //Pago_Servicio
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        #region Marca&Modelo
        // inserts values into their respective tables
        public bool RegisterMarca(string nombreMarca)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        //Inserting values into the database, table Marca
                        command.CommandText = "insert into Marca(Nombre) values(@nombreMarca)";

                        command.Parameters.Add("@nombreMarca", SqlDbType.Char, 18).Value = nombreMarca;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        public bool RegisterModelo(string nombreModelo, int idMarca)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        //Inserting values into the database, table Modelo
                        command.CommandText = "insert into Marca(Nombre_Modelo, ID_Marca) values(@nombreModelo, @fkMarca)";

                        command.Parameters.Add("@nombreModelo", SqlDbType.Char, 18).Value = nombreModelo;
                        command.Parameters.Add("@fkMarca", SqlDbType.Int).Value = idMarca; // FK of Marca

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }
        #endregion
        #endregion

        #region Provincia&Municipio
        // Stores provincia of the workshop
        public bool Provincia(string nameProvincia, string description)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        //Inserting values into the database, table Provincia
                        command.CommandText = "insert into Provincia(Provincia, Descripcion) values(@provincia, @descripcion)";

                        command.Parameters.Add("@provincia", SqlDbType.VarChar, 30).Value = nameProvincia;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }

        // Stores municipio of the workshop
        public bool Municipio(string nameMunicipio, string description, int idProvincia)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlTransaction transaction;
                    //Start transaction
                    transaction = connection.BeginTransaction();

                    //Replace this part with stored procedures
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {
                        //Inserting values into the database, table Municipio
                        command.CommandText = "insert into Provincia(Municipio, Descripcion, ID_Provincia)" +
                                          "values(@municipio, @descripcion, @idProvincia)";

                        command.Parameters.Add("@municipio", SqlDbType.VarChar, 70).Value = nameMunicipio;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;
                        command.Parameters.Add("@idProvincia", SqlDbType.Int).Value = idProvincia;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        { /* Write the update part here */ }

                        SqlDataReader reader = command.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                        Console.WriteLine("  Message: {0}", e.Message);
                        try
                        {
                            transaction.Rollback();
                            return false;
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Rollback Exception Type: {0}", e2.GetType());
                            Console.WriteLine("  Message: {0}", e2.Message);
                            return false;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
