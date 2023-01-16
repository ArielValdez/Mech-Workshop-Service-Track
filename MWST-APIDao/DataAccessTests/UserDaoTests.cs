using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;

namespace DataAccessTests
{
    [TestClass]
    class UserDaoTests
    {
        // check this later
        [TestMethod]
        public void LoginIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.Login("Ariel Valdez", "1234");
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void UserHistoryIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.UserHistory(1, 2);
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void VehicleIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.CheckVehicle("A222222");
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void MaintenanceIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.CheckMaintenance(1);
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void ServiceIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.CheckService(1);
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void ConditionIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.RegisterCondition();
            var validate = check == true ? true : false;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void PaymentIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.CheckPayment(1);
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void PartsIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.CheckParts(1);
            var validate = check;

            Assert.AreEqual(validate, check);
        }

        [TestMethod]
        public void WorkshopIsValid()
        {
            UserDao userdao = new UserDao();
            var check = userdao.CheckWorkshop(1);
            var validate = check;

            Assert.AreEqual(validate, check);
        }
    }
}
