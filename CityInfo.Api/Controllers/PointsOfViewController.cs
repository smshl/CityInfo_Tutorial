using CityInfo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{viewId}", Name = "GetPointsOfView")]
        public IActionResult GetPointsOfView(int cityId, int viewId)
        {
            var city = CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null) return NotFound();

            var result = city.PointsOfView.FirstOrDefault(p => p.Id == viewId);


            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("new")]
        public ActionResult<PointOfViewDto> PostNewPointOfView(int cityId, PointOfViewDtoForCreation pointOfViewDto)
        {
            if (!ModelState.IsValid) return BadRequest();


            var city = CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var maxPointId = CitiesDataStore.instance.Cities.SelectMany(c => c.PointsOfView).Max(p => p.Id);

            PointOfViewDto newPoint = new PointOfViewDto
            {
                Id = ++maxPointId,
                Name = pointOfViewDto.Name,
                Description = pointOfViewDto.Description,
            };

            city.PointsOfView.Add(newPoint);

            return CreatedAtAction("GetPointsOfView", new { cityId = cityId, viewId = newPoint.Id }, newPoint);

        }

        [HttpPut("update/{viewId}")]
        public ActionResult<PointOfViewDto> UpdatePointOfView(int cityId, int viewId, PointOfViewDtoForUpdate pointOfView)
        {
            var city = CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) return NotFound();

            var pointToEdit = city.PointsOfView.FirstOrDefault(p => p.Id == viewId);

            if (pointToEdit == null) return NotFound();

            pointToEdit.Name = pointOfView.Name;
            pointToEdit.Description = pointOfView.Description;

            return NoContent();
        }

        [HttpPatch("update/{viewId}/patch")]
        public ActionResult<PointOfViewDto> UpdatePointOfViewWithPatch(int cityId, int viewId, JsonPatchDocument<PointOfViewDtoForUpdate> patchDocument)
        {
            var city = CitiesDataStore.instance.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) return NotFound();

            var point = city.PointsOfView.FirstOrDefault(p => p.Id == viewId);
            if(point == null) return NotFound();

            PointOfViewDtoForUpdate updatedPoint = new PointOfViewDtoForUpdate { Name = point.Name, Description = point.Description };

            patchDocument.ApplyTo(updatedPoint, ModelState);

            if (!ModelState.IsValid) return BadRequest();

            point.Name = updatedPoint.Name;
            point.Description = updatedPoint.Description;

            return NoContent();
        }

    }
}
