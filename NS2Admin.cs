﻿using NS2AdminLib.Common;
using NS2AdminLib.JSONClasses;
using System;
using System.Net;
using Newtonsoft.Json;

namespace NS2AdminLib
{
    public class NS2Admin : IDisposable
    {
        private string baseURL;
        private NetworkCredential credentials;

        public string BaseURL { get { return this.baseURL; } }

        public NS2Admin(string username, string password, string domain, int port = 80)
        {
            this.baseURL = string.Format("http://{0}:{1}/", domain, port);
            this.credentials = new NetworkCredential(username, password);
        }

        public NS2ServerInfo GetServerInfo()
        {
            string response = JSON.GetJSONData(this.baseURL, this.credentials, false);
            return JsonConvert.DeserializeObject<NS2ServerInfo>(response);
        }

        public string Rcon(string command)
        {
            string url = string.Concat(this.baseURL, @"?request=json&command=Send&rcon=", WebUtility.UrlEncode(command));
            return JSON.GetJSONData(url, this.credentials, false);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    this.baseURL = null;
                    this.credentials = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NS2Admin() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
