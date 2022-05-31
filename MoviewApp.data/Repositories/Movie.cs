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
        CoreDbContext _movieDbContext;

        public Movie(CoreDbContext movieDbContext)
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
            var movie = _movieDbContext.movieModel.Find(movieId);
            _movieDbContext.movieModel.Remove(movie);
            _movieDbContext.SaveChanges();
        }

        public object getMovieById(int movieId)
        {
            var findmovie = _movieDbContext.movieModel.Find(movieId);
            if (findmovie != null)
            {
                return findmovie;
            }
            else
            {
                return "movie not found ";
            }
        }

        public IEnumerable<MovieModel> GetMovies()
        {
            return _movieDbContext.movieModel.ToList();
        }

        public void UpdateMovie(MovieModel movieModel)
        {
            _movieDbContext.Entry(movieModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
    }
}
