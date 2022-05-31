using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTimeController : ControllerBase
    {
        MovieTimeService _movieTimeService;

        public MovieTimeController(MovieTimeService movieTimeService)
        {
            _movieTimeService = movieTimeService;
        }

        [HttpPost("AddMovieTime")]
        public IActionResult AddMovieTime(MovieShowTime showMovieTime)
        {
            return Ok(_movieTimeService.AddMovieTime(showMovieTime));
        }

        [HttpGet("ShowAllMovieTime")]
        public IActionResult ShowAllMovieTime()
        {
            return Ok(_movieTimeService.ShowAllMovie());
        }
    }
}
