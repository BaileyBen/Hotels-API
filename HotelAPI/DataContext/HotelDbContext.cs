using HotelAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.DataContext
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
