namespace CarParts.Areas.Admin.Views.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Admin;
    public class AddAdminFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
    }
}