using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Mvc;
using Dreadmare.Managers;

//using System.ServiceModel;
//using System.ServiceModel.Syndication;

namespace Dreadmare.Controllers
{
    public class MovieController : ApiController
    {
        MovieManager movieManager = new MovieManager();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Movie/GetReviews/")]
        public IHttpActionResult GetReviews()
        {
            return Ok(movieManager.GetMovieReviewList());
        }

       

    }
}
