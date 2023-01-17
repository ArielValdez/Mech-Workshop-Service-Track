using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        // Method for test purposes
        public DataTable GetUsers()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        command.CommandText = "select * from tblUsuario";

                        command.CommandType = CommandType.Text;
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);

                            return table;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }
        #region Access
        public DataTable Login(string username, string password)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users credential
                        command.CommandText = "select * from tblUsuario where Username=@username and uPassword=@password";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.CommandType = CommandType.Text;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable UserHistory(int idUser, int idHistory)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckHistory";                    

                        command.Parameters.AddWithValue("@idUsuario", idUser);
                        command.Parameters.AddWithValue("@idHistory", idHistory);

                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable CheckVehicle(string matricula)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users vehicle
                        command.CommandText = "sp_CheckVehicle";

                        command.Parameters.AddWithValue("@matricula", matricula);

                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable CheckMaintenance(int idMaintenance)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckMaintenance";
                        command.Parameters.AddWithValue("@idMaintenance", idMaintenance);
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable CheckService(int idService)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckService";
                        
                        command.Parameters.AddWithValue("@idService", idService);
                        command.CommandType = CommandType.StoredProcedure;
                        
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable CheckCondition(int idCondition)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckCondition";
                        
                        command.Parameters.AddWithValue("@idCondition", idCondition);

                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable CheckPayment(int idPayment) {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckPayment";
                        
                        command.Parameters.AddWithValue("@idPayment", idPayment);

                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public bool CheckDetail(int idPayment) {
            //
            return false;
        }

        public DataTable CheckParts(int idParts) {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckParts";
                        
                        command.Parameters.AddWithValue("@idParts", idParts);

                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
            }
        }

        public DataTable CheckWorkshop (int idWorkshop) {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;

                        //Selects the users history
                        command.CommandText = "sp_CheckWorkshop";
                        
                        command.Parameters.AddWithValue("@idWorkshop", idWorkshop);

                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            table.Load(reader);
                            return table;
                        }
                        else
                        {
                            return table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return null;
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
            #region Phone Number
            if (string.IsNullOrEmpty(telefono)) telefono = celular;
            if (string.IsNullOrEmpty(celular)) celular = telefono;
            if (string.IsNullOrEmpty(telefono) && string.IsNullOrEmpty(celular)) telefono = "None"; celular = telefono;
            #endregion
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
                        //Inserting values into the database, table Usuario
                        command.CommandText = $"insert into tblUsuario(Nombre, Apellido, Rol, Activo, Cedula, Username, uPassword, TelefonoFijo, Celular, Email, Fecha_Creacion) " +
                                                $"Values(@nombre, @apellido, @rol, {1}, @cedula, @username, @password, @telefono, @celular, @email, @fechaCreacion) ";

                        command.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                        command.Parameters.Add("@apellido", SqlDbType.VarChar, 30).Value = apellido;
                        command.Parameters.Add("@rol", SqlDbType.Char, 1).Value = rol;

                        command.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                        command.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                        command.Parameters.Add("@cedula", SqlDbType.Char, 11).Value = cedula;
                        command.Parameters.Add("@telefono", SqlDbType.Char, 13).Value = telefono;
                        command.Parameters.Add("@celular", SqlDbType.Char, 13).Value = celular;
                        command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                        command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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

        public bool RegisterVehicle(string matricula, int idUsuario, int idMarca, int idModelo, string vin /*,string color*/)
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
                        command.CommandText = "sp_RegisterVehicle";

                        command.Parameters.Add("@matricula", SqlDbType.Char, 7).Value = matricula;
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario; // FK of Usuario
                        command.Parameters.Add("@idMarca", SqlDbType.Int).Value = idMarca; // FK of Marca
                        command.Parameters.Add("@idModelo", SqlDbType.Int).Value = idModelo; // FK of Modelo
                        command.Parameters.Add("@vin", SqlDbType.Char, 17).Value = vin;
                        //command.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = color;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterMaintenance";

                        command.Parameters.Add("@tipoMantenimiento", SqlDbType.VarChar, 30).Value = TipoMantenimiento;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterHistory";

                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        command.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;
                        command.Parameters.Add("@fecha", SqlDbType.DateTime2).Value = fecha;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        SqlDataReader reader = command.ExecuteReader();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterReceiptDetalle";

                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService;
                        command.Parameters.Add("@idVehicle", SqlDbType.Int).Value = idVehicle;
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        //Check these values later
                        command.Parameters.Add("@fechaInicio", SqlDbType.DateTime2).Value = fechaInicio;
                        command.Parameters.Add("@fechaPromesa", SqlDbType.DateTime2).Value = fechaPromesa;
                        command.Parameters.Add("@fechaEntrega", SqlDbType.DateTime2).Value = fechaEntrega;

                        //Inserting data into "Pago"
                        command.CommandText = "sp_RegisterReceiptPago";

                        // "Forma_Pago" (way2Pay) should store enums (Credito, Debito)
                        command.Parameters.Add("@way2Pay", SqlDbType.VarChar, 25).Value = way2Pay; //Forma_Pago
                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService; //Pago_Servicio
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterMarca";

                        command.Parameters.Add("@nombreMarca", SqlDbType.Char, 18).Value = nombreMarca;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterModelo";

                        command.Parameters.Add("@nombreModelo", SqlDbType.Char, 18).Value = nombreModelo;
                        command.Parameters.Add("@fkMarca", SqlDbType.Int).Value = idMarca; // FK of Marca

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterProvincia";

                        command.Parameters.Add("@provincia", SqlDbType.VarChar, 30).Value = nameProvincia;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_RegisterMunicipio";

                        command.Parameters.Add("@municipio", SqlDbType.VarChar, 70).Value = nameMunicipio;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;
                        command.Parameters.Add("@idProvincia", SqlDbType.Int).Value = idProvincia;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "update tblUsuario " +
                        "set Nombre = @nombre, Apellido = @apellido, Rol = @rol, " +
                        "Username = @username, uPassword = @password, Cedula = @cedula, TelefonoFijo = @telefono, Celular = @celular, Email = @email, Fecha_Creacion = @fechaCreacion " +
                        "where ID_Usuario = @idUsuario";

                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                        command.Parameters.Add("@apellido", SqlDbType.VarChar, 30).Value = apellido;
                        command.Parameters.Add("@cedula", SqlDbType.Char, 11).Value = cedula;
                        command.Parameters.Add("@rol", SqlDbType.VarChar, 13).Value = rol; // Replace this with an enum value

                        command.CommandType = CommandType.Text;
                        
                        command.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                        command.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                        command.Parameters.Add("@telefono", SqlDbType.Char, 13).Value = telefono;
                        command.Parameters.Add("@celular", SqlDbType.Char, 13).Value = celular;
                        command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                        command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);

                        command.CommandType = CommandType.Text;
                        transaction.Commit();
                        return true;
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

        public bool UpdateVehicle(int idVehiculo, string matricula, int idUsuario, int idMarca, int idModelo, string vin/*, string color*/)
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
                        command.CommandText = "sp_UpdateVehicle";

                        command.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                        command.Parameters.Add("@matricula", SqlDbType.Char, 7).Value = matricula;
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario; // FK of Usuario
                        command.Parameters.Add("@idMarca", SqlDbType.Int).Value = idMarca; // FK of Marca
                        command.Parameters.Add("@idModelo", SqlDbType.Int).Value = idModelo; // FK of Modelo
                        command.Parameters.Add("@vin", SqlDbType.Char, 17).Value = vin;
                        //command.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = color;

                        command.CommandType = CommandType.StoredProcedure;
                        int reader = command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateMaintenance";

                        command.Parameters.AddWithValue("@idMantenimiento", idMantenimiento);
                        command.Parameters.Add("@tipoMantenimiento", SqlDbType.VarChar, 30).Value = TipoMantenimiento;

                        command.CommandType = CommandType.StoredProcedure;
                        int reader = command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateHistory";

                        command.Parameters.AddWithValue("@idHistory", idHistory);
                        command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        command.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;
                        command.Parameters.Add("@fecha", SqlDbType.DateTime2).Value = fecha;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateReceiptDetalle";

                        command.Parameters.AddWithValue("@idReceipt", idReceipt);
                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService;
                        command.Parameters.Add("@idVehicle", SqlDbType.Int).Value = idVehicle;
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        //Check these values later
                        command.Parameters.Add("@fechaInicio", SqlDbType.DateTime2).Value = fechaInicio;
                        command.Parameters.Add("@fechaPromesa", SqlDbType.DateTime2).Value = fechaPromesa;
                        command.Parameters.Add("@fechaEntrega", SqlDbType.DateTime2).Value = fechaEntrega;

                        //Inserting data into "Pago"
                        command.CommandText = "sp_UpdateReceiptPago";

                        // "Forma_Pago" (way2Pay) should store enums (Credito, Debito)
                        command.Parameters.AddWithValue("@idReceipt", idReceipt);
                        command.Parameters.Add("@way2Pay", SqlDbType.VarChar, 25).Value = way2Pay; //Forma_Pago
                        command.Parameters.Add("@payService", SqlDbType.Decimal).Value = payService; //Pago_Servicio
                        command.Parameters.Add("@idService", SqlDbType.Int).Value = idService;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateMarca";

                        command.Parameters.AddWithValue("@idMarca", idMarca);
                        command.Parameters.Add("@nombreMarca", SqlDbType.Char, 18).Value = nombreMarca;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateModelo";

                        command.Parameters.AddWithValue("@idModelo", idModelo);
                        command.Parameters.Add("@nombreModelo", SqlDbType.Char, 18).Value = nombreModelo;
                        command.Parameters.Add("@fkMarca", SqlDbType.Int).Value = idMarca; // FK of Marca

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateProvincia";

                        command.Parameters.AddWithValue("@idProvincia", idProvincia);
                        command.Parameters.Add("@provincia", SqlDbType.VarChar, 30).Value = nameProvincia;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "sp_UpdateMunicipio";

                        command.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                        command.Parameters.Add("@municipio", SqlDbType.VarChar, 70).Value = nameMunicipio;
                        command.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = description;
                        command.Parameters.Add("@idProvincia", SqlDbType.Int).Value = idProvincia;

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblUsuario where ID_Usuario = @idUsuario";
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblVehiculo where ID_Vehiculo = @idVehiculo";

                        command.Parameters.AddWithValue("@idVehiculo", idVehiculo);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblMantenimiento where ID_Mantenimiento = @idMantenimiento";

                        command.Parameters.AddWithValue("@idMantenimiento", idMantenimiento);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblEstado where ID_Estado = @idCondition";

                        command.Parameters.AddWithValue("@idCondition", idCondition);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblHistorial where ID_Historial = @idHistory";

                        command.Parameters.AddWithValue("@idHistory", idHistory);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblDetalle where ID_Pago = @idReceipt";

                        command.Parameters.AddWithValue("@idReceipt", idReceipt);

                        //Inserting data into "Pago"
                        command.CommandText = "delete Pago ID_Pago = @idReceipt";

                        command.Parameters.AddWithValue("@idReceipt", idReceipt);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblMarca where ID_Marca = @idMarca";

                        command.Parameters.AddWithValue("@idMarca", idMarca);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "delete tblModelo where ID_Modelo = @idModelo";

                        command.Parameters.AddWithValue("@idModelo", idModelo);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "update tblProvincia where ID_Provincia = @idProvincia";

                        command.Parameters.AddWithValue("@idProvincia", idProvincia);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
                        command.CommandText = "update tblMunicipio where ID_Municipio = @idMunicipio";

                        command.Parameters.AddWithValue("@idMunicipio", idMunicipio);

                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
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
