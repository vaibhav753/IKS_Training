﻿using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    interface ITheatre
    {
        string Register(TheatreModel theatreModel);

        string UpdateTheatre(TheatreModel theatreModel);
        string Delete(int theatreId);
        object SelectTheatre();
    }
}
