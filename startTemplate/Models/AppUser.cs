using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace startTemplate.Models
{
    // My application user class inherit all attributes from IdentityUser
    public class AppUser : IdentityUser
    {
        // Custom variable
        public string Password { get; set; }
    }
}
