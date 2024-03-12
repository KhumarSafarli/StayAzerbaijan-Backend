using Microsoft.AspNetCore.Mvc;
using StayAzerbaijan.DAL;
using StayAzerbaijan.Entities;
using StayAzerbaijan.Helpers;
using StayAzerbaijan.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data;

namespace StayAzerbaijan.Controllers
{
    public class AccountController : Controller
    {
        private readonly ProductDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(ProductDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            CustomUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Due to overtrying your account has been blocked for 5 minutes");
                    return View();
                }

                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

       [HttpPost]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View();
    }

    var user = new CustomUser()
    {
        FullName = model.Firstname + " " + model.Surname,
        Email = model.Email
    };

    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

    if (!result.Succeeded)
    {
        foreach (IdentityError error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View();
    }

    await _userManager.AddToRoleAsync(user, Roles.Member.ToString());

    return RedirectToAction(nameof(Login)); 
}


        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
