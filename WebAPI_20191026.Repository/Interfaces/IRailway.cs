using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_20191026.Repository.Interfaces
{
    public interface IRailway
    {
        Task<(int statusCode, string result)> GetTrainSearch(object search);
        Task<(int statusCode, string result)> GetStationSearch(object search);
    }
}
