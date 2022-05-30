using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;

namespace MovieApp.Business.Service
{
    public class MovieServices
    {
        //MovieDbContext _movieDbContext;
        IMovie _movie;

        public MovieServices(IMovie movie)
        {
            _movie = movie;
        }
        public void AddMovie(MovieModel movieModel)
        {
            
            _movie.AddMovie(movieModel);

        }

        public void DeletMovie(int movieId)
        {
            _movie.DeletMovie(movieId);
        }

        public object getMovieById(int movieId)
        {
           return _movie.getMovieById(movieId);
        }

        public IEnumerable<MovieModel> GetMovies()
        {
            return _movie.GetMovies();
        }

        public void UpdateMovie(MovieModel movieModel)
        {
            _movie.UpdateMovie(movieModel);
        }
    }
}
