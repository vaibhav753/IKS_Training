using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;
using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieServices _movieService;

        public MovieController(MovieServices movieServices)
        {
            _movieService = movieServices;
        }

        [HttpPost]
        public IActionResult AddMovie( MovieModel movieModel)
        {
            _movieService.AddMovie(movieModel);
            return Ok("Movie created successfuly");
        }

        [HttpGet]
        public IEnumerable<MovieModel> GetMovies()
        {
            return  _movieService.GetMovies();
        }
    }
}
