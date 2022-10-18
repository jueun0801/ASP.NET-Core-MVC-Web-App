using Assignment_12._1.Models;
using Assignment_12._1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_12._1.Controllers
{
    public class AccountController : Controller //STEP 8. ADD ACCOUNTCONTROLLER IN CONTROLLERS FOLDER. 
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;  //creates new user
        private RoleManager<IdentityRole> roleManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            ModelState.AddModelError("", "Failed to Login");
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                Assignment_12._1.Models.User newuser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber.ToString(),
                    Email = registerViewModel.Email
                };
                var result = await userManager.CreateAsync(newuser, registerViewModel.Password);    //if data is valid new user will be created
                if (result.Succeeded)
                {
                    if (newuser.UserName == "Admin")
                    {
                        await userManager.AddToRoleAsync(newuser, "Admin");
                        await userManager.AddToRoleAsync(newuser, "Customer");  //Admin also has Customer Roles
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newuser, "Customer");
                    }
                    return RedirectToAction("Login", "Account");    //Once registered as user, user will be redirected to the Login Page
                }
                foreach(var error in result.Errors)                 //will occur if error in registering user i.e. user name already exists
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");   //Once user is logged out, user will be redirected to homepage. (Don't forget "Home" after Index pls)
        }
        public IActionResult Index()
        {
            return View();
        }
    }   // STEP 9. AFTER ACCOUNTCONTROLLER, ADD ROLES IN THE SQL SERVER DATABASE
}
