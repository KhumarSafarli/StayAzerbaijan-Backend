using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;
using System.Collections.Generic;

namespace StayAzerbaijan.ViewModels
{
    public class SearchResultViewModel
    {
        public List<Hotel> FilteredHotels { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RoomImage> roomImages { get; set; }
        public List<Category> Categories { get; set; }
        public List<HotelCategory>? HotelsCategory { get; set; }
        public List<MealType> MealTypes { get; set; }
        public RoomDetailsVM RoomDetails { get; internal set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
    }
}
