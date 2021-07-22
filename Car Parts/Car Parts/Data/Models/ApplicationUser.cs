using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Car_Parts.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
    }
}
