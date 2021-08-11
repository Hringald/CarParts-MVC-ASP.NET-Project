namespace CarParts.Models.Parts
{
    using static Data.DataConstants.Model;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AddModelFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        public string MakeId { get; set; }
        public ICollection<PartCategoryViewModel> Makes { get; set; }
    }
}