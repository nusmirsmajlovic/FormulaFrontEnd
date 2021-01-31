using formulaFrontEnd.ViewModels;
using formulaFrontEnd.ViewModels.RaceViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace formulaFrontEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DriverController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("All")]
        public async Task<IActionResult> Index()
        {
            var drivers = new List<Driver>();
            var client = _httpClientFactory.CreateClient("formulaAPI");
        
            var response = await client.GetAsync("api/driver/getall");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                drivers = JsonConvert.DeserializeObject<List<Driver>>(content);
            }

            return View(drivers);
        }

        [HttpGet("races/{surname}")]
        public async Task<IActionResult> RacesInfo(string surname)
        {

            var client = _httpClientFactory.CreateClient("ergastDevApi");

            var response = await client.GetAsync($"{surname}/races.json?limit=1000");

            var parsedResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
            var anotherTest = parsedResponse.ToString();
            var raceTableResults = parsedResponse["MRData"]["RaceTable"]["Races"].Children();
            var raceTableList = raceTableResults.Select(race => race.ToObject<Race>()).ToList();

            return View(raceTableList);
        }

        [HttpGet("constructors/{surname}")]
        public async Task<IActionResult> CocstructorInfo(string surname)
        {
            var client = _httpClientFactory.CreateClient("ergastDevApi");

            var response = await client.GetAsync($"{surname}/constructors.json?limit=1000");

            var parsedResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
            var anotherTest = parsedResponse.ToString();
            var constructorTableResults = parsedResponse["MRData"]["ConstructorTable"]["Constructors"].Children();
            var constructorTableList = constructorTableResults.Select(constructor => constructor.ToObject<Constructor>()).ToList();

            return View(constructorTableList);

        }
    }

    public class MRData
    {
        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("races")]
        public RaceTable RaceTable { get; set; }
    }

    public class RaceTable
    {
        public string DriverId { get; set; }

        public List<Race> Races { get; set; }
    }
}
