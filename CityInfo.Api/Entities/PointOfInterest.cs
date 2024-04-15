namespace CityInfo.Api.Entities
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
