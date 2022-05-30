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

        [HttpPost("AddMovie")]
        public IActionResult AddMovie( MovieModel movieModel)
        {
            _movieService.AddMovie(movieModel);
            return Ok("Movie created successfuly");
        }

        [HttpGet("GetMovies")]
        public IEnumerable<MovieModel> GetMovies()
        {
            return  _movieService.GetMovies();
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            _movieService.DeletMovie(movieId);
            return Ok("Movie deleted successfully");
        }

        [HttpPut("UpdateMovie")]

        public IActionResult UpdateMovie(MovieModel movieModel)
        {
            _movieService.UpdateMovie(movieModel);
            return Ok("Movie updated successfully");
        }
        [HttpGet("getMovieById")]
        public IActionResult getMovieById(int movieId)
        {
            _movieService.getMovieById(movieId);
            return Ok("movie by Id display successfully");
        }
    }
}
