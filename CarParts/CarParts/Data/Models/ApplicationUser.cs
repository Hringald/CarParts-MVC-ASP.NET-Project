namespace CarParts.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
    }
}
