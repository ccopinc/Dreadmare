using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dreadmare.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("api/Movie/GetReviews/")]
        public IHttpActionResult GetReviews()
        {
            return Ok("Hello World");
        }
    }
}
