using Gbso.Core.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace Gbso.Core.Mvc
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller, IDisposable
    {
        private int _IdSessionState { get; set; }
        private SessionVewState _SessionVewState;
        public SessionVewState SessionVewState
        {
            get => _SessionVewState ?? (_SessionVewState = new SessionVewState(HttpContext.Session, _IdSessionState));
        }

        new public void Dispose()
        {
            
            SessionVewState.Dispose();
            base.Dispose();
        }
    }
}