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
        public bool CheckHistory(int idUser, int idHistory) {
            bool checking = userDao.UserHistory(idUser, idHistory);
            return checking;
        }

        public bool CheckVehicle(string matricula) {
            bool checking = userDao.CheckVehicle(matricula);
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

        //Check later
        public bool CheckPayment(int idService) {
            bool checking = userDao.CheckPayment(idService);
            return checking;
        }

        //Check later
        public bool CheckParts(int idPayment) {
            bool checking = userDao.CheckParts(idPayment);
            return checking;
        }

        public bool CheckWorkshop(int idWorkshop) {
            bool checking = userDao.CheckWorkshop(idWorkshop);
            return checking;
        }
        #endregion

        #region Register
        public bool RegisterAUser(string username, string password, string email, string nombre,
                                  string apellido, string cedula, string rol,
                                  string telefono, string celular)
        {
            bool registering = userDao.RegisterUser(username, password, email, nombre, apellido, cedula, rol, telefono, celular);
            return registering;
        }

        public bool RegisterUsersVehicle(string matricula, int idUser, int idMarca, int idModelo, string vin, string color)
        {
            bool registering = userDao.RegisterVehicle(matricula, idUser, idMarca, idModelo, vin, color);
            return registering;
        }

        public bool RegisterMaintenance(string tipoMantenimiento) {
            bool registering = userDao.RegisterMaintenance(tipoMantenimiento);
            return registering;
        }

        public bool RegisterHistory(int idUser, int idPago, DateTime fecha) {
            bool registering = userDao.RegisterHistory(idUser, idPago, fecha);
            return registering;
        }

        public bool RegisterReceipt(string way2Pay, double payService, int idVehicle, int idService, int idWorkshop, DateTime fechaInicio, DateTime fechaPromesa, DateTime fechaEntrega) {
            bool registering = userDao.RegisterReceipt(way2Pay, payService, idVehicle, idService, idWorkshop, fechaInicio, fechaPromesa, fechaEntrega);
            return registering;
        }
        #endregion
    }
}
