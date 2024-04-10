using CityInfo.Api.Models;

namespace CityInfo.Api.DataStore
{
    public class TurkCitiesDataStore : IDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore instance { get; } = new CitiesDataStore();

        public TurkCitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto(){Id = 0,Name = "Urmia" , Description = "The best city to live in peace",PointsOfView = new List<PointOfViewDto>{
                    new PointOfViewDto { Id = 0,Name = "Saat Square" , Description = "Centeral Square of Sari" },
                    new PointOfViewDto { Id = 1,Name = "Farhang st." , Description = "Lovely street to drive" },
                    new PointOfViewDto { Id = 2,Name = "Langar village" , Description = "Heaven, on earth" },
                }
                },
                new CityDto(){Id = 1,Name = "Ardabil" , Description = "Lovely City",PointsOfView = new List<PointOfViewDto>{
                    new PointOfViewDto { Id = 3,Name = "Azadi Square" , Description = "West of Tehran" },
                    new PointOfViewDto { Id = 4,Name = "Andarzgoo" , Description = "Lovely street to drive" },
                    new PointOfViewDto { Id = 5,Name = "Students Park" , Description = "Rainbow people" },
                }
                },
                new CityDto(){Id = 2,Name = "Tabriz"}
            };
        }
    }
}
