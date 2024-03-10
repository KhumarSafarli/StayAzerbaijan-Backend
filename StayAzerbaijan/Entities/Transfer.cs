namespace StayAzerbaijan.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string PaxCount { get; set; } = null!;
        public string Image { get; set; } = null!;

    }
}
