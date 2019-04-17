using System;
using Microsoft.AspNetCore.Identity;

namespace PolicyTest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
