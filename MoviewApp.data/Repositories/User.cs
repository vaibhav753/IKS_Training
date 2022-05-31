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
        CoreDbContext _movieDbContext;
        public User(CoreDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string Delete(int userId)
        {
            var user = _movieDbContext.userModel.Find(userId);
            if(user== null)
            {
                return "";
            }
            else
            {
                _movieDbContext.userModel.Remove(user);
                _movieDbContext.SaveChanges();
                return " deleted";
            }
                
        }

        public object Login(UserModel userModel)
        {
            UserModel userData = null;
            var user = _movieDbContext.userModel.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count > 0)
                userData = user[0];
            return userData;

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

        public object SelectUserById(int userId)
        {
            return _movieDbContext.userModel.Find(userId);
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
