using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainTests
{
    [TestClass]
    public class UserModelTest
    {
        [TestMethod]
        public void LoginUserIsTrue()
        {
            UserModel model = new UserModel();
            var check = model.LoginUser("Ariel Valdez", "1234");

            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void LoginUserIsFalse()
        {
            UserModel model = new UserModel();
            var check = model.LoginUser("Ariel Valdez", "1234");

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckHistoryIsTrue()
        {
            UserModel model = new UserModel();
            var check = model.CheckHistory(1, 2);

            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void CheckHistoryIsFalse()
        {
            UserModel model = new UserModel();
            var check = model.CheckHistory(1, 2);

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckVehicleIsTrue()
        {
            UserModel model = new UserModel();
            var check = model.CheckVehicle("A222222");

            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void CheckVehicleIsFalse()
        {
            UserModel model = new UserModel();
            var check = model.CheckVehicle("A222222");

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckMaintenanceIsTrue()
        {
            UserModel model = new UserModel();
            var check = model.CheckMaintenance(1);

            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void CheckMaintenanceIsFalse()
        {
            UserModel model = new UserModel();
            var check = model.CheckMaintenance(1);

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckServiceIsValid()
        {
            UserModel model = new UserModel();
            var check = model.CheckService(1);

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckPaymentIsValid()
        {
            UserModel model = new UserModel();
            var check = model.CheckPayment(1);

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckPartsIsValid()
        {
            UserModel model = new UserModel();
            var check = model.CheckParts(1);

            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void CheckWorkshopIsValid()
        {
            UserModel model = new UserModel();
            var check = model.CheckWorkshop(1);

            Assert.AreEqual(false, check);
        }
    }
}
