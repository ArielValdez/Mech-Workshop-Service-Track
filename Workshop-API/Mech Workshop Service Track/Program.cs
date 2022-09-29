using System;
using System.Threading;
using Domain;

namespace Mech_Workshop_Service_Track
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-6.0
            UserModel userModel = new UserModel();

            Console.WriteLine("************************************");
            Console.WriteLine("* Mech Workshop Service Track MWST *");
            Console.WriteLine("************************************");

            bool loginConfirm = userModel.LoginUser("Ariel", "1234");
            bool registerUserConfirm = userModel.RegisterAUser("Ariel", "1234", "a@a.net", "Ariel", "Valdez", "000-0000000-0", "User", "(809)000-0000", string.Empty);
            
            // The users should get to use a combobox with the names of the FK, then add their IDs into the variable
            bool registerUsersVehicle = userModel.RegisterUsersVehicle("A000000", 1, 1, 1, "A10000000000000", "RED");

            Console.WriteLine("User has logged in: {0}", loginConfirm);
            Console.WriteLine("User has registered into the database: {0}", registerUserConfirm);
            Console.WriteLine("User has register their vehicle into the database: {0}", registerUsersVehicle);

            // running and looping while the program is still open
            // while(true) {
                
            // }
        }
    }
}
