using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MWST_API.Models;

namespace MWST_API.Controllers
{
    [Route("api/Condition")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private UserModel models = new UserModel();
        private ErrorManager error = new ErrorManager();

        public ConditionController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [Route("getCondition")]
        [HttpGet]
        public JsonResult Get(int idCondition)
        {
            // Query to select the data needed. Change to stored procedures
            DataTable query = models.CheckCondition(idCondition);

            try
            {
                if (query.Rows.Count > 0)
                {
                    error.Success();
                    return new JsonResult(query);
                }
                else
                {
                    return new JsonResult("Not found");
                }
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        // Create a method to register conditions
        [Route("postCondition")]
        [HttpPost]
        public JsonResult Post(Condition condition)
        {
            // Query to insert the data needed
            bool query = models.RegisterCondition();

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Condition get!");
                }
                else
                {
                    return new JsonResult("");
                }
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        // Upload an image to the database
        // Check later, as it needs a proper way to be handled
        [Route("saveImage")]
        [HttpPost]
        public JsonResult SaveFile([FromBody] FileModel file)
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                file.FileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + file.FileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(file.FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Excetion Type: {0}", e.GetType());
                Console.WriteLine("Exception Message: {0}", e.Message);
                return new JsonResult("searching car.png");
            }
        }

        [Route("putCondition")]
        [HttpPut]
        public JsonResult Put(Condition condition)
        {
            bool query = models.UpdateCondition();

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Condition updated!");
                }
                else
                {
                    return new JsonResult("Nothing to see");
                }
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }

        [Route("deleteCondition")]
        [HttpDelete]
        public JsonResult deleteCondition(int idCondition)
        {
            bool query = models.DeleteCondition(idCondition);

            try
            {
                if (query)
                {
                    error.Success();
                    return new JsonResult(error.ErrorCode + ": " + error.ErrorMessage + "\n\r" + "Condition deleted!");
                }
                else
                {
                    return new JsonResult("");
                }
            }
            catch (Exception e)
            {
                error.ErrorCode = "400";
                error.ErrorMessage = "Something went wrong";
                error.Exception = "Get Exception Type: " + e.GetType() + "\n\r" + "  Message: " + e.Message;
                return new JsonResult($"{error.ErrorMessage}: {error.ErrorMessage}\n\r{error.Exception}");
            }
        }
    }
}
