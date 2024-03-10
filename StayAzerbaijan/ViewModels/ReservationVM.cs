using StayAzerbaijan.Entities;
using StayAzerbaijan.Models;

namespace StayAzerbaijan.ViewModels
{
    public class ReservationVM
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public List<MealType> MealTypes { get; set; }
        public RoomDetailsVM RoomDetails { get; internal set; }
    }
}
