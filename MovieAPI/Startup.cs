using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Entity;
using MovieApp.Business.Service;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Repositories;
using MovieApp.Data;
using MovieApp.Data.DataConnection;
using Microsoft.OpenApi.Models;

namespace MovieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnection = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(sqlConnection));
            services.AddTransient<IUser, User>();
            services.AddTransient<IMovie, Movie>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<MovieServices, MovieServices>();
            services.AddControllers();
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            app.UseRouting();
            app.UseSwagger();
        
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieAPI");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
