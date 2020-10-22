using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Gbso.App.Api
{
    public class AppControllerBase : ControllerBase
    {

        protected readonly string MainConnectionString;
        protected readonly string MainApiUrl;

        protected readonly IConfiguration Configuration;
        public AppControllerBase(IConfiguration configuration)
        {
            Configuration = configuration;
            MainConnectionString = Configuration.GetConnectionString("GbsoApp");

        }
    }
}