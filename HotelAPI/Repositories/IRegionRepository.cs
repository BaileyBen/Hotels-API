using HotelAPI.Models.Domain;

namespace HotelAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetRegionsASync();
        Task<Region> GetRegionIdAsync(Guid id);
        Task<Region> AddRegionAsync(Region region);
        Task<Region> DeleteRegionAsync(Guid id);
        Task<Region> UpdateRegionAsync(Guid id, Region region);
    }
}
