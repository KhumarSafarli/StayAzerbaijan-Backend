using StayAzerbaijan.Entities;

namespace StayAzerbaijan.ViewModels
{
    public class HotelsVM
    {
        public List<Hotel> Hotels { get; set; }
        public List<Category>? Categories { get; set; }
        public List<HotelCategory>? HotelsCategory { get; set; }
    }
}
