using Microsoft.AspNetCore.Identity;

namespace StayAzerbaijan.Entities
{
    public class CustomUser : IdentityUser
    {
        public string FullName { get; set; } = null!;

    }
}
