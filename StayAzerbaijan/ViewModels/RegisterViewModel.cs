using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string Firstname { get; set; } = null!;
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string Surname { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
