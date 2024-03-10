namespace StayAzerbaijan.Entities
{
    public class HotelCategory
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int CategoryId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        public Category Category { get; set; } = null!;


        public override string ToString()
        {
            return Category.Name;
        }
    }

}
