using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StayAzerbaijan.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.Areas.Admin.ViewModels
{
    public class CreateHotelVM
    {
        [Required(ErrorMessage = "Please provide a name for the hotel")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide the price per night")]
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }
        [ValidateNever]
        public ICollection<Category> Categories { get; set; } = null!;
        [Required(ErrorMessage = "Please provide the location of the hotel")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please provide a description for the hotel")]
        public string Description { get; set; }

        [Display(Name = "Main Photo")]
        public IFormFile MainPhoto { get; set; }
        [Required(ErrorMessage = "Please provide a star rating for the hotel")]
        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5")]
        public int Star { get; set; }
        [Display(Name = "Slider Photo")]
        public IFormFile SliderPhoto { get; set; }

        [Display(Name = "Available on Weekend")]
        public bool IsAvailableOnWeekend { get; set; }
        public ICollection<int> CategoryIds { get; set; } = null!;


    }
}
