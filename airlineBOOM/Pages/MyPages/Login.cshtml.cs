using System;
using System.Threading.Tasks;
using airlineBOOM.Data;
using airlineBOOM.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace airlineBOOM.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        [BindProperty]
        public AppUser AppUser { get; set; }

        // Import users & login managers
        public LoginModel(
            AppDbContext db,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Login
        public async Task<IActionResult> OnPostLogin()
        {
            // Logout any previos session
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            // Login user
            var result = await _signInManager.PasswordSignInAsync(AppUser.UserName, AppUser.Password, false, false);

            if (result.Succeeded) { return RedirectToPage("/index"); }
            else { return Content("User login failed", "text/html"); }

        }

        // Logout
        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            // await _signInManager.SignOutAsync();
            return RedirectToPage("/index");
        }

        // [Authorize(Roles="Pilot","Office","FlightOperator")]
        // [Authorize] -> This allow everyone with a role.
        public IActionResult Private()
        {
            return Content("This is accesible only when login.", "text/html");
        }
    }
}