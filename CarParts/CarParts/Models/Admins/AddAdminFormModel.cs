namespace CarParts.Models.Admins
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