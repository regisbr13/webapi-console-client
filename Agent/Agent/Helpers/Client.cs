using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Helpers
{
    public class ClientApi
    {
        public string _uriApi = "http://accessapi.regislimaprojects.site/api/";

        /// <summary/>
        public async Task<HttpResponseMessage> Login(string request, string content)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(_uriApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var user = new StringContent(content, Encoding.UTF8, "application/json");

                    return await client.PostAsync(request, user);
                }
            }
        }

        /// <summary/>
        public async Task<HttpResponseMessage> Get(string request)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(_uriApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return await client.GetAsync(request);
                }
            }
        }

        /// <summary/>
        public async Task<HttpResponseMessage> Post(string request, string content)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(_uriApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = new StringContent(content, Encoding.UTF8, "application/json");

                    return await client.PostAsync(request, json);
                }
            }
        }

        /// <summary/>
        public async Task<HttpResponseMessage> Put(string request, string content)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(_uriApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = new StringContent(content, Encoding.UTF8, "application/json");

                    return await client.PutAsync(request, json);
                }
            }
        }

        /// <summary/>
        public async Task<HttpResponseMessage> Delete(string request, string content)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(_uriApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return await client.DeleteAsync(request);
                }
            }
        }
    }
}