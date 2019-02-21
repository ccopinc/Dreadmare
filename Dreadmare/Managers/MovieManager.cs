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
        

        public List<MovieReview> GetMovieReviewList()
        {
            var lmr = db.movie_Review.ToList();
            List<MovieReview>reviews = new List<MovieReview>();
            return AutoMapper.Mapper.Map(lmr,reviews);

        }
    }
}