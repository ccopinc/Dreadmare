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

        public GetReviews GetReviewById(int id)
        {
            var dbReview = db.movie_Review.Where(r => r.id_Review == id).FirstOrDefault();
            GetReviews review = new GetReviews()
            {
                Reviewer = GetReviewer(dbReview.id_Reviewer).FirstName,
                ReviewTitle = dbReview.ReviewTitle,
                MovieTitle = dbReview.MovieTitle,
                SoundPoints = dbReview.SoundPoints,
                TotalPoints = dbReview.TotalScore,
                ActingPoints = dbReview.ActingPoints,
                OverAllPoints = dbReview.OverAllPoints,
                EffectsPoints = dbReview.EffectsPoints,
                ScriptPoints = dbReview.ScriptPoints,
                Review = dbReview.Review
            };
            // short date
            DateTime d = dbReview.ReviewDate.Value;
            review.ReviewDate = d.ToShortDateString();
            return review;
        }

        public up_movie_GetReviewerInfo_Result GetReviewer(int id)
        {
            string name = "";
            var user = db.up_movie_GetReviewerInfo(id).FirstOrDefault();
            return user;
        }
    }
}