﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using Dreadmare.DTOModels;
using AutoMapper;
using System.Net;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Dreadmare.Managers
{
    public class MovieManager
    {
        dm_dbEntities db = new dm_dbEntities();
        string apiKey = "c1eac364";

        public ReviewsViewModel GetMovieReviewList()
        {
            var lmr = db.movie_Review.OrderBy(r => r.MovieTitle).ToList();
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

        public ReviewDetails GetReviewById(int id)
        {
            var dbReview = db.movie_Review.Where(r => r.id_Review == id).FirstOrDefault();
            ReviewDetails review = new ReviewDetails()
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

            review = GetMovieDetails(review);

            return review;
        }


        public ReviewDetails GetMovieDetails(ReviewDetails review)
        {
            // used for http://www.omdbapi.com
           

            //First Check if movie exists in db
            var movie = db.movie_Details.Where(m => m.Title == review.MovieTitle).FirstOrDefault();
            if (movie == null)
            {
                // Get Movie
                var client = new WebClient();
                string url = "http://www.omdbapi.com?t=" + review.MovieTitle + "&apikey=" + apiKey;
                var response = client.DownloadString(url);

                // Save movie to db
                var m = JsonConvert.DeserializeObject<MovieDetails>(response);
                var dbMovie = new movie_Details()
                {
                    Actors = m.Actors,
                    DVD = m.DVD,
                    Director = m.Director,
                    Genre = m.Genre,
                    Production = m.Production,
                    Rated = m.Rated,
                    Released = m.Released,
                    Runtime = m.Runtime,
                    Writer = m.Writer,
                    Awards = m.Awards,
                    BoxOffice = m.BoxOffice,
                    IMDBID = m.IMDBID,
                    IMDBRating = m.IMDBRating,
                    IMDBVotes = m.IMDBVotes,
                    Country = m.Country,
                    Metascore = m.Metascore,
                    Plot = m.Plot,
                    Title = m.Title,
                    Poster =m.Poster
                };
               db.movie_Details.AddOrUpdate(dbMovie);
                var er = db.GetValidationErrors();
                db.SaveChanges();
                



                review.Movie = new MovieDetails()
                {
                    Actors = m.Actors,
                    DVD = m.DVD,
                    Director = m.Director,
                    Genre = m.Genre,
                    Production = m.Production,
                    Rated = m.Rated,
                    Released = m.Released,
                    Runtime = m.Runtime,
                    Writer = m.Writer,
                    Awards = m.Awards,
                    BoxOffice = m.BoxOffice,
                    IMDBID = m.IMDBID,
                    IMDBRating = m.IMDBRating,
                    IMDBVotes = m.IMDBVotes,
                    Country = m.Country,
                    Metascore = m.Metascore,
                    Plot = m.Plot,
                    Title = m.Title,
                    Poster = m.Poster
                };
            }
            else
                { 
                    review.Movie = new MovieDetails()
                    {
                        Title = movie.Title,
                        Plot = movie.Plot,
                        Actors = movie.Actors,
                        Director = movie.Director,
                        Rated = movie.Rated,
                        Production = movie.Production,
                        Released = movie.Released,
                        Runtime = movie.Runtime,
                        Genre = movie.Genre,
                        Writer = movie.Writer,
                        DVD = movie.DVD,
                        Poster = movie.Poster
                    };

                }
            return review;
        }

        public up_movie_GetReviewerInfo_Result GetReviewer(int id)
        {
            string name = "";
            var user = db.up_movie_GetReviewerInfo(id).FirstOrDefault();
            return user;
        }

        public int GetReviewerByUName(string uName)
        {
            string name = "";
            var user = db.core_User.Where(u => u.UserName == uName).FirstOrDefault();
            return user.id_User;
        }

        public MovieDetails GetMovieDetailsByIMDBID(string id)
        {
            if (id == "")
            {
                return null;
            }
            MovieDetails movie = new MovieDetails();
            string url = "http://www.omdbapi.com?i=" + id + "&apikey=" + apiKey;
            var client = new WebClient();
            var response = client.DownloadString(url);
            movie = JsonConvert.DeserializeObject<MovieDetails>(response);
            return movie;
        }

        public GetReviews SaveReview(GetReviews review)
        {
            // Get total points avg score
            int sum = review.ActingPoints + review.EffectsPoints + review.SoundPoints + review.ScriptPoints +
                      review.OverAllPoints;
            Double avg = sum / 5;
            Double tp = Math.Round(avg, 0);
            review.TotalPoints = int.Parse(tp.ToString());
            review.id_Reviewer = GetReviewerByUName(review.Reviewer);

            //  Parse out year from movie title
            var s = review.MovieTitle.Split('(');
            review.MovieTitle = s[0];

            movie_Review movieReview = new movie_Review()
            {
                IMDB_ID = review.IMDBID,
                MovieTitle = review.MovieTitle,
                ReviewTitle = review.ReviewTitle,
                id_Reviewer = review.id_Reviewer,
                ActingPoints = review.ActingPoints,
                OverAllPoints = review.OverAllPoints,
                TotalScore = review.TotalPoints,
                SoundPoints = review.SoundPoints,
                ScriptPoints = review.ScriptPoints,
                EffectsPoints = review.EffectsPoints,
                ReviewDate = DateTime.Now.Date,
                Review = review.Review
            };
            db.movie_Review.AddOrUpdate(movieReview);
            db.SaveChanges();
            return review;
        }
    }
}