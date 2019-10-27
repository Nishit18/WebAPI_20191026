using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_20191026.Repository.Interfaces
{
    public interface IHttpClientApi 
    {
        Task<(int statusCode, string result)> PostAsync(string url, StringContent input);
        Task<(int statusCode, string result)> GetAsync(string url);
    }
}
