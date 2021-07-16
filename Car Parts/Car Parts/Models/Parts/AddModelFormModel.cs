namespace Car_Parts.Models.Parts
{
    using static Data.DataConstants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AddModelFormModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = DefaultMinLength)]
        public string Name { get; init; }
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        public string MakeId { get; set; }
        public ICollection<CategoryMakeModelView> Makes { get; set; }
    }
}