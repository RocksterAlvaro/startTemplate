using System.Threading.Tasks;
using startTemplate.Data;
using startTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace startTemplate.Pages.MyPages
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
            var result = await _userManager.CreateAsync(AppUser, AppUser.Password);

            // Add to the user a role
            // await _userManager.AddToRoleAsync(AppUser, "Pilot");

            if (result.Succeeded) {  return RedirectToPage("/index");    }
            else {  return Content("User creation failed", "text/html");    }
            
        }
    }
}