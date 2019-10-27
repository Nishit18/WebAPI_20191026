using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI_20191026.Repository.Interfaces;

namespace WebAPI_20191026.Repository.Repositories
{
    public class Railway : IRailway
    {
        public async Task<(int statusCode, string result)> GetTrainSearch(object search)
        {
            var url = "https://trains.p.rapidapi.com/";
            var content = new StringContent(JsonConvert.SerializeObject(search), Encoding.UTF8, "application/json");
            content.Headers.Add("x-rapidapi-key", "218fdc0bafmsh8ea6900df3f2766p133418jsn352e4ec6089d");
            content.Headers.Add("x-rapidapi-host", "trains.p.rapidapi.com");
            (int statusCode, string result) = await HttpClientApi.PostAsync(url, content);
            return (statusCode, result);
        }

        public async Task<(int statusCode, string result)> GetStationSearch(object search)
        {
            var url = "https://rstations.p.rapidapi.com/";
            var content = new StringContent(JsonConvert.SerializeObject(search), Encoding.UTF8, "application/json");
            content.Headers.Add("x-rapidapi-key", "218fdc0bafmsh8ea6900df3f2766p133418jsn352e4ec6089d");
            content.Headers.Add("x-rapidapi-host", "rstations.p.rapidapi.com");
            (int statusCode, string result) = await HttpClientApi.PostAsync(url, content);
            return (statusCode, result);
        }

        public async Task<(int statusCode, string result)> GetPNRStatus(object search)
        {
            var jObject = JObject.FromObject(search);
            var url = "https://indianrailways.p.rapidapi.com/index.php?pnr=" + (string)jObject["pnr"];
            var content = new StringContent("", Encoding.UTF8, "application/json");
            content.Headers.Add("x-rapidapi-key", "218fdc0bafmsh8ea6900df3f2766p133418jsn352e4ec6089d");
            content.Headers.Add("x-rapidapi-host", "indianrailways.p.rapidapi.com");
            (int statusCode, string result) = await HttpClientApi.PostAsync(url, content);
            return (statusCode, result);
        }
    }
}
