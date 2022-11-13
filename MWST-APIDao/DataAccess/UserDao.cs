using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        #region Access
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
            }
        }

        public bool CheckService(int idService)
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
            }
        }

        public bool CheckCondition(int idCondition)
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
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

                        connection.Close();
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
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return false;
            }
        }
        #endregion

        #region Register
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool RegisterCondition() {
            return false;
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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
                        command.CommandText = "insert into Modelo(Nombre_Modelo, ID_Marca) values(@nombreModelo, @fkMarca)";

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

        // Stores provincia of the workshop
        public bool RegisterProvincia(string nameProvincia, string description)
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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
        public bool RegisterMunicipio(string nameMunicipio, string description, int idProvincia)
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

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        #region Full Update
        public bool UpdateUser(int idUsuario, string username, string password, string email, string nombre,
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
                        command.CommandText = "update PerfilUsuario" +
                                                "set Username = @username, Password = @password, Telefono = @telefono, Celular = @celular, Email = @email, FechaCreacion = @fechaCreacion" +
                                                "where ID_Usuario = idUsuario";
                        
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                        command.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                        command.Parameters.Add("@telefono", SqlDbType.Char, 13).Value = telefono;
                        command.Parameters.Add("@celular", SqlDbType.Char, 13).Value = celular;
                        command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                        command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);

                        command.CommandText = "update Usuario" +
                                               "Nombre = @nombre, Apellido = @apellido, Cedula = @cedula, Rol = @rol" +
                                                "where ID_Usuario = @idUsuario";
                        
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                        command.Parameters.Add("@apellido", SqlDbType.VarChar, 30).Value = apellido;
                        command.Parameters.Add("@cedula", SqlDbType.Char, 11).Value = cedula;
                        command.Parameters.Add("@celular", SqlDbType.VarChar, 13).Value = rol; // Replace this with an enum value

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool UpdateVehicle(int idVehiculo, string matricula, int idUsuario, int idMarca, int idModelo, string vin, string color)
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
                        command.CommandText = "update Vehiculo" +
                                          "set ID_Usuario = @idUsuario, ID_Marca = @idMarca, ID_Modelo = @idModelo, VIN = @vin, Color = @color" +
                                          "where Matricula = @matricula or ID_Vehiculo = @idVehiculo";

                        command.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                        command.Parameters.Add("@matricula", SqlDbType.Char, 7).Value = matricula;
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario; // FK of Usuario
                        command.Parameters.Add("@idMarca", SqlDbType.Int).Value = idMarca; // FK of Marca
                        command.Parameters.Add("@idModelo", SqlDbType.Int).Value = idModelo; // FK of Modelo
                        command.Parameters.Add("@vin", SqlDbType.Char, 17).Value = vin;
                        command.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = color;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool UpdateMaintenance(int idMantenimiento, string TipoMantenimiento)
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
                        command.CommandText = "update Mantenimiento set Tipo_Mantenimiento = @tipoMantenimiento where ID_Mantenimiento = @idMantenimiento";

                        command.Parameters.AddWithValue("@idMantenimiento", idMantenimiento);
                        command.Parameters.Add("@tipoMantenimiento", SqlDbType.VarChar, 30).Value = TipoMantenimiento;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (!reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool UpdateCondition() //
        {
            return false;
        }

        public bool UpdateHistory(int idHistory, int idUsuario, int idPago, DateTime fecha)
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
                        command.CommandText = "update Historial set ID_Usuario = @idUsuario, ID_Pago = @idPago, Fecha = @fecha where ID_Historial = @idHistory";

                        command.Parameters.AddWithValue("@idHistory", idHistory);
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        command.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;
                        command.Parameters.Add("@fecha", SqlDbType.DateTime2).Value = fecha;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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
        public bool UpdateReceipt(int idReceipt, string way2Pay, double payService, int idVehicle, int idService, int idWorkshop, DateTime fechaInicio, DateTime fechaPromesa, DateTime fechaEntrega)
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
                        //Inserting values into the database, table Detalle
                        command.CommandText = "update Detalle" +
                                              "set Pago_Servicio = @payService, ID_Vehiculo = @idVehicle, ID_Servicio = @idService, FechaInicio = @fechaInicio, FechaPromesa = @fechaPromesa, FechaEntrega = @fechaEntrega" +
                                              "where ID_Pago = @idReceipt";

                        command.Parameters.AddWithValue("@idReceipt", idReceipt);
                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService;
                        command.Parameters.Add("@idVehicle", SqlDbType.Int).Value = idVehicle;
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        //Check these values later
                        command.Parameters.Add("@fechaInicio", SqlDbType.DateTime2).Value = fechaInicio;
                        command.Parameters.Add("@fechaPromesa", SqlDbType.DateTime2).Value = fechaPromesa;
                        command.Parameters.Add("@fechaEntrega", SqlDbType.DateTime2).Value = fechaEntrega;

                        //Inserting data into "Pago"
                        command.CommandText = "update Pago" +
                                              "set Forma_Pago = @way2pay, Pago_Servicio = @payService, ID_Servicio = idService)" +
                                              "where ID_Pago = @idReceipt";

                        // "Forma_Pago" (way2Pay) should store enums (Credito, Debito)
                        command.Parameters.AddWithValue("@idReceipt", idReceipt);
                        command.Parameters.Add("@way2Pay", SqlDbType.VarChar, 25).Value = way2Pay; //Forma_Pago
                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService; //Pago_Servicio
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool UpdateMarca(int idMarca, string nombreMarca)
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
                        command.CommandText = "update Marca set Nombre = @nombreMarca where ID_Marca = @idMarca";

                        command.Parameters.AddWithValue("@idMarca", idMarca);
                        command.Parameters.Add("@nombreMarca", SqlDbType.Char, 18).Value = nombreMarca;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
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

        public bool UpdateModelo(int idModelo, string nombreModelo, int idMarca)
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
                        command.CommandText = "update Modelo set Nombre_Modelo = @nombreModelo, ID_Marca = @fkMarca where ID_Modelo = @idModelo";

                        command.Parameters.AddWithValue("@idModelo", idModelo);
                        command.Parameters.Add("@nombreModelo", SqlDbType.Char, 18).Value = nombreModelo;
                        command.Parameters.Add("@fkMarca", SqlDbType.Int).Value = idMarca; // FK of Marca

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
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

        public bool UpdateProvincia(int idProvincia, string nameProvincia, string description)
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
                        command.CommandText = "update Provincia set Provincia = @provincia, Descripcion = @descripcion where ID_Provincia = @idProvincia";

                        command.Parameters.AddWithValue("@idProvincia", idProvincia);
                        command.Parameters.Add("@provincia", SqlDbType.VarChar, 30).Value = nameProvincia;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool UpdateMunicipio(int idMunicipio, string nameMunicipio, string description, int idProvincia)
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
                        command.CommandText = "update Municipio" +
                                          "set Municipio = @municipio, Descripcion = @descripcion, ID_Provincia = @idProvincia" +
                                          "where ID_Municipio = @idMunicipio";

                        command.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                        command.Parameters.Add("@municipio", SqlDbType.VarChar, 70).Value = nameMunicipio;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;
                        command.Parameters.Add("@idProvincia", SqlDbType.Int).Value = idProvincia;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        // For the Back Office BO
        #region Delete
        public bool DeleteUser(int idUsuario)
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
                        command.CommandText = "delete PerfilUsuario where ID_Usuario = idUsuario";
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

                        //Inserting values into the database, table Usuario
                        command.CommandText = "delete Usuario where ID_Usuario = idUsuario";

                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool DeleteVehicle(int idVehiculo)
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
                        command.CommandText = "delete Vehiculo where ID_Vehiculo = @idVehiculo";

                        command.Parameters.AddWithValue("@idVehiculo", idVehiculo);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool DeleteMaintenance(int idMantenimiento)
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
                        command.CommandText = "delete Mantenimiento where ID_Mantenimiento = @idMantenimiento";

                        command.Parameters.AddWithValue("@idMantenimiento", idMantenimiento);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool DeleteCondition(int idCondition)
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
                        command.CommandText = "delete Estado where ID_Estado = @idCondition";

                        command.Parameters.AddWithValue("@idCondition", idCondition);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool DeleteHistory(int idHistory)
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
                        command.CommandText = "delete Historial where ID_Historial = @idHistory";

                        command.Parameters.AddWithValue("@idHistory", idHistory);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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
        public bool DeleteReceipt(int idReceipt)
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
                        command.CommandText = "delete Detalle where ID_Pago = @idReceipt";

                        command.Parameters.AddWithValue("@idReceipt", idReceipt);

                        //Inserting data into "Pago"
                        command.CommandText = "delete Pago ID_Pago = @idReceipt";

                        command.Parameters.AddWithValue("@idReceipt", idReceipt);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool DeleteMarca(int idMarca)
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
                        command.CommandText = "delete Marca where ID_Marca = @idMarca";

                        command.Parameters.AddWithValue("@idMarca", idMarca);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
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

        public bool DeleteModelo(int idModelo)
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
                        command.CommandText = "delete Modelo where ID_Modelo = @idModelo";

                        command.Parameters.AddWithValue("@idModelo", idModelo);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
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

        public bool DeleteProvincia(int idProvincia)
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
                        command.CommandText = "update Provincia where ID_Provincia = @idProvincia";

                        command.Parameters.AddWithValue("@idProvincia", idProvincia);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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

        public bool DeleteMunicipio(int idMunicipio)
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
                        command.CommandText = "update Municipio where ID_Municipio = @idMunicipio";

                        command.Parameters.AddWithValue("@idMunicipio", idMunicipio);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        connection.Close();
                        if (reader.HasRows)
                        {
                            transaction.Commit();
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            reader.Close();
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
