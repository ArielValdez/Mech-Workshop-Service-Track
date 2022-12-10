using System;
using System.Threading;
using Domain;
// using System.Net.Http;
// using Newtonsoft.Json.Linq;

namespace Mech_Workshop_Service_Track
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-6.0
            // API Console
            UserModel user = new UserModel();
            user.LoginUser("Ariel", "1234");
        }
    }
}
