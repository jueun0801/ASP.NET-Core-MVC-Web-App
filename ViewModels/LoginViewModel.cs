using System.ComponentModel.DataAnnotations;

namespace Assignment_12._1.ViewModels
{
    public class LoginViewModel //STEP 7. ADD LOGINVIEWMODEL CLASS IN VIEW MODELS FOLDER
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
