using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;
using System.Collections.Generic;

namespace StayAzerbaijan.ViewModels
{
    public class ReservationVM
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public List<Room> Rooms { get; set; } 
        public List<Hotel> FilteredHotels { get; set; }
        public List<MealType> MealTypes { get; set; }
        public RoomDetailsVM RoomDetails { get; set; }
        public DateTime CheckInDate { get; internal set; }
        public DateTime CheckOutDate { get; internal set; }
        public int PaxCount { get; internal set; }
        public int Nights { get; internal set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string SelectedRoomType { get; set; }
        public string PromoCode { get; set; }
        public decimal PromoCodeDiscount { get; set; }
        public List<Promocode> Promocodes { get; set; }
    }
}
