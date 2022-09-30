using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Mech_Workshop_Service_Track.controllers
{
    public static class UserController
    {
        public static async void GetUser()
        {
            string url = "http://";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (data != null)
                            {
                                //Now log your data in the console
                                Console.WriteLine("data: {0}", data);
                            }
                            else
                            {
                                Console.WriteLine("There is no data");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Commit Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
            }
        }
    }
}
