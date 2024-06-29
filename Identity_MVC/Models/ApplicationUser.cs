using Microsoft.AspNetCore.Identity;

namespace Identity_MVC.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Address {  get; set; }
    }
}
