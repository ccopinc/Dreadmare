using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dreadmare.DTOModels;
using AutoMapper;


namespace Dreadmare.Managers
{
    public class MovieManager
    {
        dm_dbEntities db = new dm_dbEntities();
        

        public ReviewsViewModel GetMovieReviewList()
        {
            var lmr = db.movie_Review.ToList();
            List<GetReviews>reviews = new List<GetReviews>();
            var list = AutoMapper.Mapper.Map(lmr, reviews);
            foreach(movie_Review mr in lmr)
            {
                GetReviews r = new GetReviews()
                {
                    id_Review =  mr.id_Review,
                    Reviewer = GetReviewer(mr.id_Reviewer).FirstName,
                    UserReviewCount = GetReviewer(mr.id_Reviewer).Reviews.ToString(),
                    IMDBID = mr.IMDB_ID,
                    MovieTitle =  mr.MovieTitle,
                    ReviewTitle = mr.ReviewTitle,
                    Review = mr.Review,
                    OverAllPoints = mr.OverAllPoints,
                    ScriptPoints = mr.ScriptPoints,
                    SoundPoints = mr.SoundPoints,
                    EffectsPoints = mr.EffectsPoints,
                    ActingPoints = mr.ActingPoints,
                    TotalPoints =  mr.TotalScore
                };
                // short date
                DateTime d = mr.ReviewDate.Value;
                r.ReviewDate = d.ToShortDateString();

                reviews.Add(r);
            }

            ReviewsViewModel MovieReviews = new ReviewsViewModel();
            MovieReviews.Reviews = reviews;
            
            return MovieReviews;

        }

        public up_movie_GetReviewerInfo_Result GetReviewer(int id)
        {
            string name = "";
            var user = db.up_movie_GetReviewerInfo(id).FirstOrDefault();
            return user;
        }
    }
}