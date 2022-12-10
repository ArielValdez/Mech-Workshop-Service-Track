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

namespace MWST_API.Controllers
{
    // Requirement Provincia

    [Route("api/Municipio")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly Connection con = new Connection();
        private UserModel models = new UserModel();

        public MunicipioController()
        {
        }

        [Route("getMunicipio")]
        [HttpGet]
        public JsonResult Get()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            return new JsonResult("Not implemented yet.");
        }

        [Route("postMunicipio")]
        [HttpPost]
        public JsonResult Post()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            return new JsonResult("Not implemented yet.");
        }

        [Route("putMunicipio")]
        [HttpPut]
        public JsonResult Put()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            return new JsonResult("Not implemented yet.");
        }

        [Route("deleteMunicipio")]
        [HttpDelete]
        public JsonResult Delete()
        {
            // This should not delete a row. Instead, put a user as "ïnactive".
            return new JsonResult("Not implemented yet.");
        }
    }
}
