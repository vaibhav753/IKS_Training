using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IUser
    {

        string Register(UserModel userModel);
        object Login(UserModel userModel);
        string Update(UserModel usermodel);
        string Delete(int userId);
        object SelectUser();
        object SelectUserById(int userId);
    }
}
