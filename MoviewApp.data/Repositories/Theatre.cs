using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    class Theatre 
    {
        MovieDbContext _movieDbContext;

        public Theatre(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        //public string Delete(int theatreId)
       // {
            //string msg = "";
            //var theatre = _movieDbContext.theatreModel.Find(theatreId);
            //// _movieDbContext.movieModel.Remove(theatre);
            //_movieDbContext.Entry(theatre).State = EntityState.Deleted;
            //_movieDbContext.SaveChanges();
            //msg = "Deleted ";
            //return msg;
       // }

        public string Register(TheatreModel theatreModel)
        {
            throw new NotImplementedException();
        }

        public object SelectTheatre()
        {
            throw new NotImplementedException();
        }

        public string UpdateTheatre(TheatreModel theatreModel)
        {
            throw new NotImplementedException();
        }
    }
}
