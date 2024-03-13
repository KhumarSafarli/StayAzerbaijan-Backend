using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.Areas.Admin.ViewModels
{
    public class CreateCategoryVM
    {
        [Required(ErrorMessage = "Category name is required.")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Category name cannot contain only whitespace characters.")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Name { get; set; } = null!;
    }
}
