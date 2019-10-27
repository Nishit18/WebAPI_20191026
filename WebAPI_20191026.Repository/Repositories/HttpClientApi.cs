using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI_20191026.Repository.Interfaces;

namespace WebAPI_20191026.Repository.Repositories
{
    public class HttpClientApi
    {
        public static async Task<(int statusCode, string result)> PostAsync(string url, StringContent input)
        {
            var response = new HttpResponseMessage();
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.PostAsync(url, input);
                httpClient.Dispose();
            }
            return ((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
