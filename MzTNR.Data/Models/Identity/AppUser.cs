using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MzTNR.Data.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        /*
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;*/
        public ICollection<AppUserRole>? UserRoles { get; set; }
    }
}