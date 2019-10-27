using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_20191026.Repository.Interfaces;

namespace WebAPI_20191026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RailwayController : ControllerBase
    {
        private IRailway railway;

        public RailwayController(IRailway _railway)
        {
            railway = _railway;
        }

        //Search Indian Railway trains by either train number or it's name
        //Search train using train number or train keyword
        //Request JSON is below
        //{
        //  "search": "queen"
        //}
        [HttpPost("SearchTrain")]
        public async Task<IActionResult> SearchTrain(object search)
        {
            try
            {
                (int statusCode, string responseContent) = await railway.GetTrainSearch(search);
                return StatusCode(statusCode, responseContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.ToString());
            }
        }

        //Search Indian Railway station by either code or it's name
        //Request JSON is below
        //{
        //  "search":"delhi"
        //}
        [HttpPost("SearchStation")]
        public async Task<IActionResult> SearchStation(object search)
        {
            try
            {
                (int statusCode, string responseContent) = await railway.GetStationSearch(search);
                return StatusCode(statusCode, responseContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.ToString());
            }
        }
    }
}