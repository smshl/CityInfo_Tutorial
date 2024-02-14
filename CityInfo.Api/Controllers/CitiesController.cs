using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;
using System.Text;

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
        [HttpGet("{cityId}/Places")]
        public ActionResult GetPlaces(int cityId)
        {
            var result = CitiesDataStore.instance.Cities.Where(c => c.Id == cityId).FirstOrDefault().PointsOfView.ToList();

            if(result == null) return NotFound();

            return Ok(result);
        }
    }
}
