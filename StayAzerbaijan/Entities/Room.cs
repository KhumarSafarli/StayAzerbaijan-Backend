  namespace StayAzerbaijan.Entities
    {
        public class Room
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int HotelId { get; set; }
            public Hotel Hotel { get; set; }
            public string BedType { get; set; }
            public string Landscape { get; set; }
            public int Capacity { get; set; }
        public int Size { get; set; }
           public ICollection<RoomImage> RoomImages { get; set; }
    }
    }


