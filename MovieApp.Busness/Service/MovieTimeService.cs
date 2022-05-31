using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Service
{
    public class MovieTimeService
    {
        IMovieTime _imovieTime;

        public MovieTimeService(IMovieTime imovieTime)
        {
            _imovieTime = imovieTime;
        }

        public string AddMovieTime(MovieShowTime showMovieTime)
        {
            return _imovieTime.AddMovieTime(showMovieTime);
        }

        public List<MovieShowTime> ShowAllMovie()
        {
            return _imovieTime.showAllMovie();
        }
    }
}
