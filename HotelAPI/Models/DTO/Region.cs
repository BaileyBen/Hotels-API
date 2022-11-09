namespace HotelAPI.Models.DTO
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
    }
}
