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
            get {
                return _SessionVewState ?? (_SessionVewState = new SessionVewState(HttpContext.Session, _IdSessionState));
            }
        }

        new public void Dispose()
        {
            SessionVewState.Dispose();
            base.Dispose();
        }
    }
}
namespace Gbso.Core.Session
{
    public class SessionVewState : IDisposable
    {
        protected bool _Loadel;
        protected int _idSessionVewState;
        protected ISession Session { get; set; }

        private Dictionary<string, object> _ViewState;
        private Dictionary<string, object> VewState
        {
            get
            {
                if (_ViewState != null)
                    return _ViewState;
                byte[] subSession;
                if (((DistributedSession)Session).TryGetValue(_idSessionVewState.ToString(), out subSession))
                {
                    using (MemoryStream memoryStream = new MemoryStream(subSession))
                    {
                        return _ViewState = (Dictionary<string, object>)new BinaryFormatter().Deserialize(memoryStream);
                    }
                }
                return _ViewState = new Dictionary<string, object>();
            }
            set
            {
                _ViewState = value;
            }
        }

        public SessionVewState(ISession session, int idSessionVewState)
        {
            Session = session;
            _idSessionVewState = idSessionVewState;
            if (!_Loadel)
            Task.Run(async () =>
            {
                await Session.LoadAsync();
                _Loadel = true;
            });
        }

        public object this[string key]
        {
            get => VewState.ContainsKey(key) ? VewState[key] : null;
            set
            {
                if (VewState.ContainsKey(key))
                    VewState[key] = value;
                else
                    VewState.Add(key, value);
            }
        }
        
        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_ViewState != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            new BinaryFormatter().Serialize(memoryStream, _ViewState);
                            Task.Run(async () =>
                            {
                                await Session.LoadAsync();
                                Session.Set(_idSessionVewState.ToString(), memoryStream.ToArray());
                                _Loadel = true;
                            });
                        }
                    }
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~SessionVewState() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    //public static class SessionExtensions
    //{

    //    public static void AsyncSetObject(this ISession Session, string key, object value)
    //    {
    //        Session.LoadAsync();
    //        Session.SetString(key, JsonConvert.SerializeObject(value));
    //    }

    //    public static TEntity AsyncGetObject<TEntity>(this ISession session, string key)
    //    {
    //        session.LoadAsync();
    //        var value = session.GetString(key);
    //        return value == null ? default(TEntity) : JsonConvert.DeserializeObject<TEntity>(value);
    //    }

    //    public static dynamic AsyncGetObject(this ISession session, string key)
    //    {
    //        session.LoadAsync();
    //        var value = session.GetString(key);
    //        return value == null ? null : JsonConvert.DeserializeObject(value);
    //    }

    //    public static void SetObject(this ISession Session, string key, object value)
    //    {
    //        Session.SetString(key, JsonConvert.SerializeObject(value));
    //    }

    //    public static dynamic GetObject(this ISession session, string key)
    //    {
    //        var value = session.GetString(key);
    //        return value == null ? null : JsonConvert.DeserializeObject(value);
    //    }

    //}

}
