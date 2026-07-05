using Microsoft.AspNetCore.Identity;

namespace Book_store.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
