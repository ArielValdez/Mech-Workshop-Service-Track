using System;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        private readonly UserDao userDao = new UserDao();
        #region Access
        public bool LoginUser(string username, string password)
        {
            bool satisfactoryLogin = userDao.Login(username, password);
            Console.WriteLine("Login access: {0}", satisfactoryLogin);
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
        public bool CheckMaintenance(int idMaintenance) {
            bool checking = userDao.CheckMaintenance(idMaintenance);
            return checking;
        }

        //Check later
        public bool CheckService(int idService) {
            bool checking = userDao.Service(idService);
            return checking;
        }

        //Check later
        public bool CheckCondition(int idCondition) {
            bool checking = userDao.CheckCondition(idCondition);
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

        public bool RegisterMarca(string marca) {
            bool registering = userDao.RegisterMarca(marca);
            return registering;
        }

        public bool RegisterModelo(string modelo, int idMarca){
            bool registering = userDao.RegisterModelo(modelo, idMarca);
            return registering;
        }

        public bool RegisterProvincia(string nameProvincia, string description) {
            bool registering = userDao.RegisterProvincia(nameProvincia, description);
            return registering;
        }

        public bool RegisterMunicipio(string nameMunicipio, string description, int idProvincia) {
            bool registering = userDao.RegisterMunicipio(nameMunicipio, description, idProvincia);
            return registering;
        }

        public bool RegisterCondition(){
            bool registering = userDao.RegisterCondition();
            return registering;
        }
        #endregion

        #region Full Update: Post
        public bool UpdateUser(int idUsuario, string username, string password, string email, string nombre,
                                 string apellido, string cedula, string rol,
                                 string telefono, string celular)
        {
            bool updating = userDao.UpdateUser(idUsuario, username, password, email, nombre, apellido, cedula, rol, telefono, celular);
            return updating;
        }

        public bool UpdateVehicle(int idVehiculo, string matricula, int idUsuario, int idMarca, int idModelo, string vin, string color)
        {
            bool updating = userDao.UpdateVehicle(idVehiculo, matricula, idUsuario, idMarca, idModelo, vin, color);
            return updating;
        }

        public bool UpdateMaintenance(int idMantenimiento, string TipoMantenimiento)
        {
            bool updating = userDao.UpdateMaintenance(idMantenimiento,TipoMantenimiento);
            return updating;
        }

        // Check later
        public bool UpdateCondition()
        {
            bool updating = userDao.UpdateCondition();
            return updating;
        }

        public bool UpdateHistory(int idHistory, int idUsuario, int idPago, DateTime fecha)
        {
            bool updating = userDao.UpdateHistory(idHistory, idUsuario, idPago, fecha);
            return updating;
        }

        // Check ID of Workshop
        public bool UpdateReceipt(int idReceipt, string way2Pay, double payService, int idVehicle, int idService, int idWorkshop, DateTime fechaInicio, DateTime fechaPromesa, DateTime fechaEntrega)
        {
            bool updating = userDao.UpdateReceipt(idReceipt, way2Pay, payService, idVehicle, idService, idWorkshop, fechaInicio, fechaPromesa, fechaEntrega);
            return updating;
        }

        public bool UpdateMarca(int idMarca, string nombreMarca)
        {
            bool updating = userDao.UpdateMarca(idMarca, nombreMarca);
            return updating;
        }

        public bool UpdateModelo(int idModelo, string nombreModelo, int idMarca)
        {
            bool updating = userDao.UpdateModelo(idModelo, nombreModelo, idMarca);
            return updating;
        }

        public bool UpdateProvincia(int idProvincia, string nameProvincia, string description)
        {
            bool updating = userDao.UpdateProvincia(idProvincia, nameProvincia, description);
            return updating;
        }

        public bool UpdateMunicipio(int idMunicipio, string nameMunicipio, string description, int idProvincia)
        {
            bool updating = userDao.UpdateMunicipio(idMunicipio, nameMunicipio, description, idProvincia);
            return updating;
        }
        #endregion

        #region Partial Update: Patch
        #endregion
    }
}
