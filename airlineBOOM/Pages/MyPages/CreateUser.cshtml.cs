using System.Threading.Tasks;
using airlineBOOM.Data;
using airlineBOOM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace airlineBOOM.Pages.MyPages
{
    public class CreateUserModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        [BindProperty]
        public AppUser AppUser { get; set; }

        // Import users & login managers
        public CreateUserModel(
            AppDbContext db,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Create user
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _userManager.CreateAsync(AppUser, AppUser.Password); // Create the user on the database

            var userRole = Request.Form["userRole"]; // Get the selected role by the user
            await _userManager.AddToRoleAsync(AppUser, userRole); // Add to the user a role

            if (result.Succeeded) {  return RedirectToPage("/index");    }
            else {  return Content("User creation failed", "text/html");    }
            
        }
    }
}