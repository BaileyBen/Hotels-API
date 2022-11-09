using HotelAPI.Models.Domain;

namespace HotelAPI.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<Hotel> AddHotelAsync(Hotel hotel);
        Task<Hotel> DeleteHotelAsync(Guid id);  
        Task<Hotel> UpdateHotelAsync(Guid id, Hotel hotel);
    }
}
