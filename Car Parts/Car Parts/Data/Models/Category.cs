using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Car_Parts.Data.Models
{
    using static DataConstants.Category;
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }
}
