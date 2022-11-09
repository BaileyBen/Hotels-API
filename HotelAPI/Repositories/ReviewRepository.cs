using HotelAPI.DataContext;
using HotelAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HotelDbContext _context;

        public ReviewRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            review.Id = Guid.NewGuid();

            await _context.Reviews.AddAsync(review);

            _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review> DeleteReviewAsync(Guid id)
        {
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if (existingReview == null)
            {
                return null;
            }

            _context.Reviews.Remove(existingReview);

            _context.SaveChangesAsync();

            return existingReview;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(Guid id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Review> UpdateReviewAsync(Guid id, Review review)
        {
            var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if (existingReview != null)
            {
                existingReview.Rating = review.Rating;
                existingReview.Comment = review.Comment;

                return existingReview;
            }

            return null;
        }
    }
}
