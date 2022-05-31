using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieTimeController : Controller
    {
        IConfiguration _configuration;

        public MovieTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddMovieTime()
        {
            List<TheatreModel> theatreModel = null;
            List<MovieModel> movieModel = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Theatre/SelectTheatre";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(data);
                    }
                }
            }

            List<SelectListItem> theatreList = new List<SelectListItem>();

            List<SelectListItem> movieList = new List<SelectListItem>();

            SelectListItem newItem = new SelectListItem();

            SelectListItem newItem2 = new SelectListItem();

            newItem.Text = "Select";
            newItem.Value = "0";
            theatreList.Add(newItem);

            foreach (var item in theatreModel)
            {
                newItem.Text = item.ThreatreName;
                int a = item.ThreatreId;
                newItem.Value = a.ToString();
                theatreList.Add(newItem);
            }

            ViewBag.theatreShowList = theatreList;
            TempData["theatreShowList"] = theatreList;

            using (HttpClient client = new HttpClient())
            {
                string endpint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(data);

                    }
                }
            }

            newItem2.Text = "Select";
            newItem2.Value = "0";
            movieList.Add(newItem2);


            foreach (var item in movieModel)
            {
                newItem2.Text = item.MovieName;
                int a = item.MovieId;
                newItem2.Value = a.ToString();
                movieList.Add(newItem2);
            }

            ViewBag.movieShowList = movieList;
            TempData["movieShowList"] = movieList;

            return RedirectToAction("AddMovieTime");
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieTime(MovieShowTime showMovieModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(showMovieModel), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "MovieTime/AddMovieTime";

                using (var response = await client.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowAllMovieShow");
                    }
                }
            }

            return RedirectToAction("ShowAllMovieShow");

        }

        [HttpGet]
        public async Task<IActionResult> ShowAllMovieShow()
        {

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "MovieTime/ShowAllMovieTime";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        List<MovieShowTime> list = JsonConvert.DeserializeObject<List<MovieShowTime>>(data);
                        return View(list);
                    }
                }
            }

            return View();
        }
    }
}
