using CityInfo.Api.DataStore;
using CityInfo.Api.Services;
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
        private readonly ILogger<CitiesController> _logger;
        private readonly IMailService _mailService;
        private readonly IDataStore _dataStore;

        public CitiesController(ILogger<CitiesController> logger, IMailService mailService, IDataStore dataStore)
        {
            _logger = logger;
            _mailService = mailService;
            _dataStore = dataStore;
        }


        [HttpGet()]
        //public JsonResult GetCities()
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.instance.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult GetCity(int id)
        {
            var result = _dataStore.Cities.FirstOrDefault(c => c.Id == id);

            if (result == null)
            {
                _logger.LogCritical("this is a test from critical logger");
                try
                {
                    _mailService.Send(subject: "test email" , body: $"this is a test body from a service i created , {_mailService} :)");
                }
                catch (Exception e)
                {
                    _logger.LogCritical("email not sent, error: " + e.Message);
                }
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("{cityId}/Places")]
        public ActionResult GetPlaces(int cityId)
        {
            var result = _dataStore.Cities.Where(c => c.Id == cityId).FirstOrDefault().PointsOfView.ToList();

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
