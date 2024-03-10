namespace StayAzerbaijan.Entities
{
    public class HotelMealType
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int MealTypeId { get; set; }
        public MealType MealType { get; set; }
    }
}
