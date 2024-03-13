using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.Areas.Admin.ViewModels
{
    public class CreatePromocodeVM
    {
        [Required(ErrorMessage = "Promocode name is required.")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Category name cannot contain only whitespace characters.")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please provide the Discount amount ")]
        [DataType(DataType.Currency)]
        public decimal DiscountAmount { get; set; }
    }
}
