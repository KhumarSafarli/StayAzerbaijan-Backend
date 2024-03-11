using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;
using System.Collections.Generic;

namespace StayAzerbaijan.ViewModels
{
    public class SearchResultViewModel
    {
        public Room Room { get; set; }
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
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public int PaxCount { get; set; }
        public int Nights { get; internal set; }
        public decimal TotalPrice { get; set; }
        public List<string> SelectedCategories { get; set; }
        public List<string> SelectedMealTypes { get; set; }
        public string SelectedRoomType { get; set; }
    }
}
