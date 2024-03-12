using StayAzerbaijan.Entities;

namespace StayAzerbaijan.Models
{
    public class RoomDetailsVM
    {  
        public Room Room { get; set; }
        public string Name { get; set; }
        public string BedType { get; set; }
        public string Landscape { get; set; }
        public string MealType { get; set; }
        public string RoomType { get; internal set; }
        public int RoomId { get; internal set; }
    }
}
