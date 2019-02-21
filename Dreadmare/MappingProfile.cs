using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Dreadmare.DTOModels;



namespace Dreadmare
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<List<movie_Review>, List<MovieReview>>();
        }
    }
}