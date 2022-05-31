using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IMovieTime
    {
        public string AddMovieTime(MovieShowTime movieTime);

        List<MovieShowTime> showAllMovie();
    }
}
