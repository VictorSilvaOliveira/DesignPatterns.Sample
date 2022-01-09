using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Sample
{
    public abstract class HttpProvedor
    {
        private readonly IHttpClient _httpClient;

        protected HttpProvedor(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal void EnviaProvedor(string path, object request)
        {
            _httpClient.Post(path, request);

        }
    }
}
