using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Gbso.App.Api
{
    public class AppController : Controller
    {

        protected readonly string MainConnectionString;
        protected readonly string MainApiUrl;

        protected readonly IConfiguration Configuration;
        public AppController(IConfiguration configuration)
        {
            Configuration = configuration;
            MainConnectionString = Configuration.GetConnectionString("GbsoApp");

        }
    }
}