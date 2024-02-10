using CityInfo.Api.Models;

namespace CityInfo.Api
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore instance { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto(){Id = 0,Name = "Sari" , Description = "The best city to live in peace"},
                new CityDto(){Id = 1,Name = "Tehran" , Description = "The Jerusalem"},
                new CityDto(){Id = 2,Name = "Shiraz"}
            };
        }
    }
}
