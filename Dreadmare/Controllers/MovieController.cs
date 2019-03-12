using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Mvc;
using Dreadmare.DTOModels;
using Dreadmare.Managers;

//using System.ServiceModel;
//using System.ServiceModel.Syndication;

namespace Dreadmare.Controllers
{
    public class MovieController : Controller
    {
        MovieManager movieManager = new MovieManager();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Movie/GetReviews/")]
        public ActionResult GetReviews()
        {
            var reviews = movieManager.GetMovieReviewList();
            return View(reviews);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Movie/ReviewDetails/{id}")]
        public ActionResult ReviewDetails(int id)
        {
            var review = movieManager.GetReviewById(id);
            return PartialView("ReviewDetails", review);
        }



        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Movie/WriteReview/")]
        public ActionResult WriteReview(GetReviews review)
        {
            return View(review);
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Movie/WriteReview/{id}")]
        public ActionResult SetMovieObject(string id)
        {

            var movie = movieManager.GetMovieDetailsByIMDBID(id);
            GetReviews review = new GetReviews()
            {
                MovieTitle = movie.Title,
                IMDBID = movie.IMDBID
            };
            ModelState.Clear();
            return View("WriteReview", review);
        }





    }
}
