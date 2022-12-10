﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MWST_API.Controllers
{
    [Route("api/Provincia")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public ProvinciaController()
        {
            
        }

        [Route("getProvincia")]
        [HttpGet]
        public JsonResult Get()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Get Request.");
            }
        }

        [Route("postProvincia")]
        [HttpPost]
        public JsonResult Post()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Post Request.");
            }
        }

        [Route("putProvincia")]
        [HttpPut]
        public JsonResult Put()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Put Request.");
            }
        }

        [Route("deleteProvincia")]
        [HttpDelete]
        public JsonResult Delete()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            try
            {
                return new JsonResult("Not implemented yet.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception Type: {0}", e.GetType());
                Console.WriteLine("  Message: {0}", e.Message);
                return new JsonResult("An error has occurred during Delete Request.");
            }
        }
    }
}
