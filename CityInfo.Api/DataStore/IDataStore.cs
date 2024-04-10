using CityInfo.Api.Models;

namespace CityInfo.Api.DataStore
{
    public interface IDataStore
    {
        List<CityDto> Cities { get; set; }
    }
}