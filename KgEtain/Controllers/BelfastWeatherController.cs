using KgEtain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KgEtain.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BelfastWeatherController : ControllerBase
    {
        private readonly IBelfastWeatherService _belfastWeatherService;

        public BelfastWeatherController(IBelfastWeatherService belfastWeatherService)
        {
            _belfastWeatherService = belfastWeatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var whereOnEarthID = await _belfastWeatherService.GetWhereOnEarthIDAsync();
            var response = await _belfastWeatherService.GetApiResponse(whereOnEarthID);           
            return Ok(response);
        }
    }
}
