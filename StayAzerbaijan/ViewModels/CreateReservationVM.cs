namespace StayAzerbaijan.ViewModels
{
    public class CreateReservationVM
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string MobileNumber { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public int PaxCount { get; set; }
        public decimal Price { get; set; }
    }
}
