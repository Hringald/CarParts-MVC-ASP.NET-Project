namespace CarParts.Models.Parts
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Make;
    public class AddMakeFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        public byte[] Image { get; set; }
    }
}