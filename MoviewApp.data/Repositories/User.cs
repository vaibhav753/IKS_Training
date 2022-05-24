using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq; 

namespace MovieApp.Data.Repositories
{
    public class User : IUser
    {
        MovieDbContext _movieDbContext;
        public User(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string Delete()
        {
            throw new NotImplementedException();
        }

        public object Login()
        {
            throw new NotImplementedException();
        }

        public string Register(UserModel userModel)
        {
           
                string msg = "";
            //insert into usermodelid,userModel.fname
            _movieDbContext.userModel.Add(userModel);
            _movieDbContext.SaveChanges();//Execute sql statement
                msg = "Inserted";
                return msg;
            

          
        }

        public object SelectUser()
        {
            List<UserModel> userList = _movieDbContext.userModel.ToList();
            return userList;
        }

        public string Update(UserModel usermodel)
        {
            string msg = "";
            _movieDbContext.Entry(usermodel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "updated";
            return msg;
        }
    }
}
