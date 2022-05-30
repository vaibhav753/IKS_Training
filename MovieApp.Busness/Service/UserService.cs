using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using MovieApp.Data.Repositories;

namespace MovieApp.Business.Service
{
    public class UserService
    {
        IUser _iuser;
        public UserService(IUser user)
        {
            _iuser = user;
        }

        public string Register(UserModel userModel)
        {

            return _iuser.Register(userModel);
        }

        public object SelectUser()
        {

            return _iuser.SelectUser();
        }

        public string Update(UserModel usermodel)
        {
            _iuser.Update(usermodel);
            return "update successfull";
        }
        public string Delete(int userId)
        {
             _iuser.Delete(userId);
            return "delete successfull";
        }
        public object Login(UserModel userModel)
        {
            return _iuser.Login(userModel);
        }

        public object SelectUserById(int userId)
        {
            return _iuser.SelectUserById(userId);
        }
    }
}
