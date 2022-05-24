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
            return _iuser.Update(usermodel);
        }

    }
}
