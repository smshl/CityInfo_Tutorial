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
            return new JsonResult
                (
                    new List<object>
                    {
                        new {id = 1, City = "Sari"},
                        new {id = 2, City = "Tehran"},
                        new {id=3, City="Isfahan"}
                    }
                );
        }
    }
}
