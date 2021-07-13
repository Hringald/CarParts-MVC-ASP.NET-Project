using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Car_Parts.Data.Models
{
    using static DataConstants;
    public class Make
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public ICollection<Model> Models { get; set; } = new HashSet<Model>();
    }
}
