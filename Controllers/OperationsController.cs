﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleProjectTwo.Controllers
{
    public class OperationsController : ApiController
    {
        [HttpOptions]
        [Route("api/refreshconfig")]
        public IHttpActionResult RefreshAppSettings()
        {
            try
            {
                ConfigurationManager.RefreshSection("AppSettings");
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }
        }
    }
}
