using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWST_API.Models
{
    public class RequestResponse
    {
        // Gets http requests and responds accordingly
        // Implement later
        private object Request { get; set; }
        private bool Response = false;

        // Status Code from Response
        public int StatusCode { get; set; }

        // Error Message from Response
        public string ErrorMessage { get; set; }

        public RequestResponse()
        {

        }

        public void Response1()
        {

        }

        public void Request1()
        {

        }

        public bool HttpRequests(string HttpRequest)
        {
            Request = HttpRequest;
            if (Request == "GET")
            {
                // Do request
                Response = true;
            }
            if (Request == "POST")
            {
                // Do request
                Response = true;
            }
            if (Request == "PUT")
            {
                // Do request
                Response = true;
            }
            if (Request == "DELETE")
            {
                // Do request
                Response = true;
            }
            return Response;
        }
    }
}
