using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StayAzerbaijan.Entities;
using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.Areas.Admin.ViewModels
{
    public class UpdateHotelVM
    {
        [ValidateNever]
        public int Id { get; set; }
        public string Name { get; set; }

       
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }
        [ValidateNever]
        public ICollection<Category> Categories { get; set; } = null!;

        [ValidateNever]
        public List<HotelCategory> HotelCategories { get; set; } = null!;

        public string Location { get; set; }
        
        public string Description { get; set; }

        [Display(Name = "Main Photo")]
        public IFormFile MainPhoto { get; set; }

        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5")]
        public int Star { get; set; }

        [Display(Name = "Slider Photo")]
        public IFormFile SliderPhoto { get; set; }

        [Display(Name = "Available on Weekend")]
        public bool IsAvailableOnWeekend { get; set; }
        public ICollection<int> CategoryIds { get; set; } = null!;
    }
}
