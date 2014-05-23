using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.Api.Client
{
    public static class HttpClientHelper
    {
        public static async Task<T> Get<T>(string path)
            where T : class
        {
            using (var client = new HttpClient())
            {
                T returnEntity = null;
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Constants.ApiUrl]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    returnEntity = await response.Content.ReadAsAsync<T>();
                }

                return returnEntity;
            }
        }

        public static async Task Post<T>(string path, T data)
            where T : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Constants.ApiUrl]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(path, data);
            }
        }

        public static async Task Put<T>(string path, T data)
            where T : class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Constants.ApiUrl]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(path, data);
            }
        }

        public static async Task Delete(string path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Constants.ApiUrl]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(path);
            }
        }
    }
}
