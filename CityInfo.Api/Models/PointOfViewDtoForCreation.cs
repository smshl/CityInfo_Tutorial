using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models
{
    public class PointOfViewDtoForCreation
    {
        //good to learn Fluent Validation, it is more professional
        [Required(ErrorMessage = "This is a test error message")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
