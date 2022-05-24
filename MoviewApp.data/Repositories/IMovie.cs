using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IMovie
    {
        public void AddMovie(MovieModel movieModel);
        public void UpdateMovie(MovieModel movieModel);

        public void DeletMovie(int movieId);
        public MovieModel getMovieById(int movieId);

        IEnumerable<MovieModel> GetMovies();
    }
}
