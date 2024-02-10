using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    //[Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet()]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.instance.Cities); 
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == id));
        }
    }
}
