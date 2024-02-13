using CityInfo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Route("api/Cities/{cityId}/pointsofview")]
    public class PointsOfViewController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<List<PointOfViewDto>> GetAllPointsOfView(int cityId)
        {
            var result =  CitiesDataStore.instance.Cities.Where(c => c.Id == cityId).SelectMany(p => p.PointsOfView).ToList();

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("{viewId}")]
        public IActionResult GetPointsOfView(int cityId, int viewId)
        {
            var city = CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null) return NotFound();

            var result = city.PointsOfView.FirstOrDefault(p => p.Id == viewId);


            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
