namespace Car_Parts.Models.Parts
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddMakeFormModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = DefaultMinLength)]
        public string Name { get; init; }
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        public byte[] Image { get; set; }
    }
}