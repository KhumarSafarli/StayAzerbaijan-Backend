using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StayAzerbaijan.Entities;
using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.Areas.Admin.ViewModels
{
    public class CreateTransferVM
    {
        [Required(ErrorMessage = "Please provide a name for the transfer")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide the price ")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please provide the Description ")]
        public string Description { get; set; } = null!;
        [ValidateNever]
        [Required(ErrorMessage = "Please provide the capacity")]
        public string PaxCount { get; set; } = null!;
        [Required(ErrorMessage = "Please provide a photo for the transfer")]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; } = null!;
    }
}
