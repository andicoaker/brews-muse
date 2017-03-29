using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public Guid Signature { get; set; }
        public List<Vendor> Vendors { get; set; }


    }
}
