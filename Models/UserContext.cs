using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment_12._1.Models   
{
    public class UserContext:IdentityDbContext<User>    //STEP 2. ADD USER CONTEXT CLASS IN MODELS
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
    }
}
