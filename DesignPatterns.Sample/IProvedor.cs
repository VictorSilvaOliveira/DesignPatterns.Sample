﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Sample
{
    public class BaseProvedor
    {
        public virtual void Publica(string nomeDoImovel, decimal valor, uint quartos)
        {
            throw new NotImplementedException();
        }

        internal void EnviaProvedor(string path, object request)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.PostAsync(path, GenerateBody(request));
        }

        private ByteArrayContent GenerateBody(object rawBody)
        {
            var myContent = JsonSerializer.Serialize(rawBody, options: new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}