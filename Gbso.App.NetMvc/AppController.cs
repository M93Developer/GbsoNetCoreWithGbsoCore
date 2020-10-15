using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Gbso.App.NetMvc
{
    public class AppController : Controller
    {

        protected readonly string MainConnectionString;
        protected readonly string MainApiUrl;

        protected readonly IConfiguration Configuration;
        public AppController(IConfiguration configuration)
        {
            Configuration = configuration;
            MainApiUrl = Configuration.GetValue<string>("ApiUrls:GbsoAppApi");

        }
        //private int _IdSessionState { get; set; }
        //private SessionVewState _SessionVewState;
        //public SessionVewState SessionVewState
        //{
        //    get => _SessionVewState ?? (_SessionVewState = new SessionVewState(HttpContext.Session, _IdSessionState));
        //}

        //new public void Dispose()
        //{

        //    SessionVewState.Dispose();
        //    base.Dispose();
        //}
    }
}