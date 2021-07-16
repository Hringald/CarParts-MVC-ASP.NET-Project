

namespace Car_Parts.Models.Parts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddPartFormModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = DefaultMinLength)]
        public string Name { get; init; }
        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }
        [Display(Name = "Make")]
        public string MakeId { get; init; }
        [Display(Name = "Model")]
        public string ModelId { get; init; }
        [Display(Name = "Category")]
        public string CategoryId { get; init; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; init; }
        [Required]
        [Range(1,100)]
        public int Quantity { get; init; }
        [Required]
        [Range(typeof(decimal), "0.01", DecimalMaxValue,ErrorMessage ="Price must be a positive number.")]
        public decimal Price { get; init; }
        public ICollection<CategoryMakeModelView> Makes { get; set; }
        public ICollection<CategoryMakeModelView> Categories { get; set; }
        public ICollection<CategoryMakeModelView> Models { get; set; }
    }
}