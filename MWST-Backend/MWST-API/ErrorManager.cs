using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWST_API
{
    public class ErrorManager
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public string Exception { get; set; }

        public ErrorManager()
        {
            this.ErrorCode = "200";
            this.ErrorMessage = "Success";
            this.Exception = "No Exception Registered";
        }

        public void Success()
        {
            this.ErrorCode = "200";
            this.ErrorMessage = "Success";
            this.Exception = "No Exception Registered";
        }
    }
}
