using System.ComponentModel.DataAnnotations;

namespace StayAzerbaijan.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
