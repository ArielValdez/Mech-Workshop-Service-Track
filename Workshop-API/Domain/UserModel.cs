using System;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        #region Access
        private readonly UserDao userDao = new UserDao();
        public bool LoginUser(string username, string password)
        {
            bool satisfactoryLogin = userDao.Login(username, password);
            return satisfactoryLogin;
        }

        //Check later
        public bool CheckHistory() {
            bool checking = userDao.UserHistory();
            return checking;
        }

        //Check later
        public bool CheckMaintenance(string tipo) {
            bool checking = userDao.CheckMaintenance(tipo);
            return checking;
        }

        //Check later
        public bool CheckService(string tipoServicio, int idMantenimiento) {
            bool checking = userDao.Service(tipoServicio, idMantenimiento);
            return checking;
        }

        //Check later
        public bool CheckCondition(string conditionName, int idService) {
            bool checking = userDao.Service(conditionName, idService);
            return checking;
        }
        #endregion

        #region Register
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
        #endregion
    }
}
