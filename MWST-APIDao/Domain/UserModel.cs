using System;
using System.Data;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        private readonly UserDao userDao = new UserDao();

        // Method for test purposes
        public DataTable Test()
        {
            return userDao.GetUsers();
        }

        #region Access: Get
        public DataTable LoginUser(string username, string password)
        {
            DataTable satisfactoryLogin = userDao.Login(username, password);
            Console.WriteLine("Login access: {0}", satisfactoryLogin);
            return satisfactoryLogin;
        }

        public DataTable CheckHistory(int idUser, int idHistory) {
            DataTable checking = userDao.UserHistory(idUser, idHistory);
            return checking;
        }

        public DataTable CheckVehicle(string matricula) {
            DataTable checking = userDao.CheckVehicle(matricula);
            return checking;
        }

        public DataTable CheckMaintenance(int idMaintenance) {
            DataTable checking = userDao.CheckMaintenance(idMaintenance);
            return checking;
        }

        public DataTable CheckService(int idService) {
            DataTable checking = userDao.CheckService(idService);
            return checking;
        }

        public DataTable CheckCondition(int idCondition) {
            DataTable checking = userDao.CheckCondition(idCondition);
            return checking;
        }

        public DataTable CheckPayment(int idService) {
            DataTable checking = userDao.CheckPayment(idService);
            return checking;
        }

        public DataTable CheckParts(int idPayment) {
            DataTable checking = userDao.CheckParts(idPayment);
            return checking;
        }

        public DataTable CheckWorkshop(int idWorkshop) {
            DataTable checking = userDao.CheckWorkshop(idWorkshop);
            return checking;
        }
        #endregion

        #region Register: Post
        public bool RegisterAUser(string username, string password, string email, string nombre,
                                  string apellido, string cedula, string rol,
                                  string telefono, string celular)
        {
            bool registering = userDao.RegisterUser(username, password, email, nombre, apellido, cedula, rol, telefono, celular);
            return registering;
        }

        public bool RegisterUsersVehicle(string matricula, int idUser, int idMarca, int idModelo, string vin/*, string color*/)
        {
            bool registering = userDao.RegisterVehicle(matricula, idUser, idMarca, idModelo, vin/*, color*/);
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

        // One for Workshop
        #endregion

        #region Full Update: Put
        public bool UpdateUser(int idUsuario, string username, string password, string email, string nombre,
                                 string apellido, string cedula, string rol,
                                 string telefono, string celular)
        {
            bool updating = userDao.UpdateUser(idUsuario, username, password, email, nombre, apellido, cedula, rol, telefono, celular);
            return updating;
        }

        public bool UpdateVehicle(int idVehiculo, string matricula, int idUsuario, int idMarca, int idModelo, string vin/*, string color*/)
        {
            bool updating = userDao.UpdateVehicle(idVehiculo, matricula, idUsuario, idMarca, idModelo, vin/*, color*/);
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

        // One for Workshop
        #endregion

        #region Partial Update: Patch
        // Nothing of note, yet
        #endregion

        #region Delete
        public bool DeleteUser(int idUser)
        {
            bool deleting = userDao.DeleteUser(idUser);
            return deleting;
        }

        public bool DeleteVehicle(int idVehicle)
        {
            bool deleting = userDao.DeleteVehicle(idVehicle);
            return deleting;
        }

        public bool DeleteMaintenance(int idMaintenance)
        {
            bool deleting = userDao.DeleteMaintenance(idMaintenance);
            return deleting;
        }

        public bool DeleteCondition(int idCondition)
        {
            bool deleting = userDao.DeleteCondition(idCondition);
            return deleting;
        }

        public bool DeleteHistory(int idHistory)
        {
            bool deleting = userDao.DeleteHistory(idHistory);
            return deleting;
        }

        public bool DeleteReceipt(int idReceipt)
        {
            bool deleting = userDao.DeleteReceipt(idReceipt);
            return deleting;
        }

        public bool DeleteMarca(int idMarca)
        {
            bool deleting = userDao.DeleteMarca(idMarca);
            return deleting;
        }

        public bool DeleteModelo(int idModelo){
            bool deleting = userDao.DeleteModelo(idModelo);
            return deleting;
        }

        public bool DeleteProvincia(int idProvincia){
            bool deleting = userDao.DeleteProvincia(idProvincia);
            return deleting;
        }

        public bool DeleteMunicipio(int idMunicipio){
            bool deleting = userDao.DeleteMunicipio(idMunicipio);
            return deleting;
        }

        // One delete for workshop
        #endregion
    }
}
