using HotelAPI.Models.Domain;

namespace HotelAPI.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(Guid id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review> DeleteReviewAsync(Guid id);
        Task<Review> UpdateReviewAsync(Guid id, Review review);
    }
}
