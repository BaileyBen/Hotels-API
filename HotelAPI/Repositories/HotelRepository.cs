using HotelAPI.DataContext;
using HotelAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> AddHotelAsync(Hotel hotel)
        {
            hotel.Id = Guid.NewGuid();

            await _context.AddAsync(hotel);

            _context.SaveChangesAsync();

            return hotel;
        }

        public async Task<Hotel> DeleteHotelAsync(Guid id)
        {
            var existingHotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHotel == null)
            {
                return null;
            }

            _context.Hotels.Remove(existingHotel);

            _context.SaveChangesAsync();

            return existingHotel;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels
                .Include(x => x.Region)
                .Include(x => x.Review)
                .ToListAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(Guid id)
        {
            return await _context.Hotels
                .Include(x => x.Region)
                .Include(x => x.Review)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Hotel> UpdateHotelAsync(Guid id, Hotel hotel)
        {
            var existingHotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHotel != null)
            {

                existingHotel.HotelName = hotel.HotelName;
                existingHotel.Price = hotel.Price;
                existingHotel.Beds = hotel.Beds;
                existingHotel.Vacancy = hotel.Vacancy;
                existingHotel.Extras = hotel.Extras;
                existingHotel.RegionId = hotel.RegionId;
                existingHotel.ReviewId = hotel.ReviewId;

                return existingHotel;
            }

            return null;
        }
    }
}
