namespace CityInfo.Api.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPointsOfViews
        {
            get
            {
                return PointsOfView.Count;
            }
        }

        public ICollection<PointOfViewDto> PointsOfView { get; set; } = new List<PointOfViewDto>();
    }
}
