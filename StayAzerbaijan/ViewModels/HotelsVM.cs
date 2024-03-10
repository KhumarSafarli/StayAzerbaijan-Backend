using StayAzerbaijan.Entities;

namespace StayAzerbaijan.ViewModels
{
    public class HotelsVM
    {
        public List<Hotel> Hotels { get; set; }
        public List<Category>? Categories { get; set; }
        public List<HotelCategory>? HotelsCategory { get; set; }
        public Hotel Hotel { get; internal set; }
        public List <Room> Rooms { get; set; }
        public List <RoomImage> RoomImages { get; set;}
    }
}
