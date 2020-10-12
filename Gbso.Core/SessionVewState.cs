using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Gbso.Core.Session
{
    public class SessionVewState : IDisposable
    {
        protected string _idSessionVewState;
        protected ISession Session { get; set; }

        private Dictionary<string, object> _ViewState;
        private Dictionary<string, object> VewState
        {
            get
            {
                if (_ViewState != null)
                    return _ViewState;
                byte[] subSession = ((DistributedSession)Session).Get(_idSessionVewState.ToString());

                if (subSession != null)
                    using (MemoryStream memoryStream = new MemoryStream(subSession))
                        return _ViewState = (Dictionary<string, object>)new BinaryFormatter().Deserialize(memoryStream);
                return _ViewState = new Dictionary<string, object>();
            }
            set => _ViewState = value;
        }

        public SessionVewState(ISession session, int idSessionVewState)
        {
            Session = session;
            //_idSessionVewState = idSessionVewState;
            _idSessionVewState = "SessionKey";
            Session.LoadAsync().Wait();
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
                        Task.Run(() => {
                            using (var memoryStream = new MemoryStream())
                            {
                                new BinaryFormatter().Serialize(memoryStream, _ViewState);
                                Session.Set(_idSessionVewState.ToString(), memoryStream.ToArray());
                                Session.CommitAsync().Wait();
                            }
                        });
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
}
