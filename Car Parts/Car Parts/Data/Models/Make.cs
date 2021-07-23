

namespace Car_Parts.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Make;
    public class Make
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string AdminId { get; set; }
        public Admin Admin { get; set; }
        [Required]
        public ICollection<Model> Models { get; set; } = new HashSet<Model>();
      
    }
}
