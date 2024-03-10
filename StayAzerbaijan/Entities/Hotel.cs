namespace StayAzerbaijan.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public decimal Star { get; set; }
        public bool IsAvailableOnWeekend { get; set; }
        public string sliderImgUrl { get; set; }
        public string MainImgUrl { get; set; }

        public ICollection<HotelCategory> HotelCategories { get; set; } = null!;
        public ICollection<Room> Rooms { get; set; } = null!;
        public ICollection<HotelMealType> HotelMealTypes { get; set; }
    }
}
