using StayAzerbaijan.Entities;

namespace StayAzerbaijan.ViewModels
{
    public class HomeVM
    {
        public ICollection<Hotel> Hotels { get; set; } = null!;
        public List<Category>? Categories { get; set; }
       
    }
}
