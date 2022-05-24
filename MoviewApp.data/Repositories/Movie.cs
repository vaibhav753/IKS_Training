using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
   public  class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddMovie(MovieModel movieModel)
        {
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();

        }

        public void DeletMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public MovieModel getMovieById(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieModel> GetMovies()
        {
            return _movieDbContext.movieModel.ToList();
        }

        public void UpdateMovie(MovieModel movieModel)
        {
            throw new NotImplementedException();
        }
    }
}
