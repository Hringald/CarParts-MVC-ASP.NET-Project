namespace Car_Parts.Models.Admins
{
    using static Data.DataConstants.Model;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Car_Parts.Models.Parts;

    public class EditModelFormModel
    {
        public string Id { get; set; }
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