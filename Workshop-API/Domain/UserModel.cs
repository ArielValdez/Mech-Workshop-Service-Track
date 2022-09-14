using System;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        private readonly UserDao userDao = new UserDao();
        public bool LoginUser(string username, string password)
        {
            // Storing the value in a variable
            bool satisfactoryLogin = userDao.Login(username, password);
            return satisfactoryLogin;
        }

        // Change data type
        public bool Register1User(string username, string password, string email, string nombre,
                                  string apellido, string cedula, string rol,
                                  string telefono, string celular)
        {
            bool registration = userDao.RegisterUser(username, password, email, nombre, apellido, cedula, rol, telefono, celular);
            return registration;
        }

        public bool RegisterUsersVehicle(string matricula, int idUsuario, int idMarca, int idModelo, string vin, string color)
        {
            bool registratingVehicle = userDao.RegisterVehicle(matricula, idUsuario, idMarca, idModelo, vin, color);
            return registratingVehicle;
        }
    }
}
