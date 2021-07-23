namespace Car_Parts.Models.Parts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Part;
    public class EditPartFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        [Display(Name = "Make")]
        public string MakeName { get; init; }
        [Display(Name = "Model")]
        public string ModelName { get; init; }
        [Display(Name = "Category")]
        public string CategoryName { get; init; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; init; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; init; }
        [Required]
        [Range(typeof(decimal), "0.01", DecimalMaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; init; }
    }
}