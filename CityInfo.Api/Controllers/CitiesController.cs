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
        //public JsonResult GetCities()
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.instance.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult GetCity(int id)
        {
            var result = CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == id);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
