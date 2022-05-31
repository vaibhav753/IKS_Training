using MovieApp.Data.DataConnection;
using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    class MovieTime :IMovieTime
    {
        MovieDbContext _movieDbContext;

        public string AddMovieTime(MovieShowTime movieTime)
        {
            _movieDbContext.MovieTime.Add(movieTime);
            _movieDbContext.SaveChanges();
            return "Movie Time Added Successfully...!!";
        }

        public List<MovieShowTime> showAllMovie()
        {
            return _movieDbContext.MovieTime.ToList();
        }
    }
}
