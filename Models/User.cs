using Microsoft.AspNetCore.Identity;

namespace Assignment_12._1.Models //STEP 1. ADD USER CLASS IN MODELS
{
    public class User:IdentityUser //User class must have all properties coming from identity user
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
