using Microsoft.EntityFrameworkCore;
using StayAzerbaijan.Entities;

namespace StayAzerbaijan.DAL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> opt) : base(opt)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HotelCategory> HotelCategories { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomsImages { get; set;}
        public DbSet <CompanyInfo> CompanyInfos { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<HotelMealType> HotelMealTypes { get; set; }
       
    }
}
