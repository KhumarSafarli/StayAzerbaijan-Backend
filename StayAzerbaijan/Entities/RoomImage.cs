namespace StayAzerbaijan.Entities
{
    public class RoomImage
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string ImgUrl { get; set; }
    }
}
