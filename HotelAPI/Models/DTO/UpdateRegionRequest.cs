namespace HotelAPI.Models.DTO
{
    public class UpdateRegionRequest
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
    }
}
