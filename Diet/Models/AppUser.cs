using Microsoft.AspNetCore.Identity;

namespace Diet.Models
{
    public enum TypeUserEnum
    {
        Patient = 0,
        Doctor
    }
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeUserEnum TypeUser { get; set; }
        public string Description { get; set; }
    }
}
