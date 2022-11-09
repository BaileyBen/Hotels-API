using HotelAPI.Models.Domain;

namespace HotelAPI.Models.DTO
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string HotelName { get; set; }
        public float Price { get; set; }
        public int Beds { get; set; }
        public string Vacancy { get; set; }
        public string Extras { get; set; }
        public Guid RegionId { get; set; }
        public Guid ReviewId { get; set; }

        public Region Region { get; set; }
        public Review Review { get; set; }
    }
}
