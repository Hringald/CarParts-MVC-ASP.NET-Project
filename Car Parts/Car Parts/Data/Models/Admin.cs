using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Car_Parts.Data.Models
{
    using static DataConstants.Admin;
    public class Admin
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public  ApplicationUser User { get; set; }
        public ICollection<Model> Models { get; init; } = new List<Model>();
        public ICollection<Make> Makes { get; set; } = new List<Make>();
    }
}
