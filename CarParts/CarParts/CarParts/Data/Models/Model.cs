namespace CarParts.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Model;
    public class Model
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public Make Make { get; set; }
        public string MakeId { get; set; }
        public Admin Admin { get; set; }
        public string AdminId { get; set; }
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }
}
