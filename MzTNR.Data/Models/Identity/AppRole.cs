using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MzTNR.Data.Models.Identity
{
    public class AppRole: IdentityRole<int>
    {
        public ICollection<AppUserRole>? UserRoles { get; set; }
    }
}