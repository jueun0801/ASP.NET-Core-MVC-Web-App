using System.ComponentModel.DataAnnotations;

namespace Assignment_12._1.ViewModels
{//STEP 7. ADD REGISTERVIEWMODEL CLASS IN VIEW MODELS FOLDER
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage ="Enter first name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Enter last name")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
