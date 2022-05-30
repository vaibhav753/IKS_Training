using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Entity;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> SelectUser()
        {
            //Fetch API,AxiosApi,HttpClient
            //Http Verbs: GET,POST,DELETE..
            //Http Req/response
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUser";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            ViewBag.status = "";
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Register";
                using(var response =await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "ok";
                        ViewBag.message = "Register successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "wrong entites";
                    }
                }
                
            }
            return View();


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int userId)
        {
            //Fetch API,AxiosApi,HttpClient
            //Http Verbs: GET,POST,DELETE..
            //Http Req/response
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUserById?userId=" + userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserModel userModel)
        {
            ViewBag.status = "";

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Update";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "ok";
                        ViewBag.message = "Register successfully";
                        return RedirectToAction("SelectUser", "User");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "wrong entites";
                    }
                }

            }
            return View();


        }

    }
}
