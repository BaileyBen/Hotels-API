using HotelAPI.DataContext;
using HotelAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly HotelDbContext _context;

        public RegionRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();

            await _context.AddAsync(region);

            await _context.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();

            return existingRegion;
        }

        public async Task<Region> GetRegionIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Region>> GetRegionsASync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Country = region.Country;
            existingRegion.State = region.State;
            existingRegion.City = region.City;
            existingRegion.Postcode = region.Postcode;

            await _context.SaveChangesAsync();

            return existingRegion;
        }
    }
}
