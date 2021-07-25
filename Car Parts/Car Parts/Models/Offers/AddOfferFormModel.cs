namespace Car_Parts.Models.Offers
{
    using Car_Parts.Models.Parts;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Offer;
    public class AddOfferFormModel : PartViewModel
    {
        [Required]
        [StringLength(NameMaxLength,MinimumLength =NameMinLength)]
        public string BuyerName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(PhoneRegex)]
        public string Phone { get; set; }
        [Required]
        [StringLength(AddressMaxLength,MinimumLength =AddressMinLength)]
        public string Address { get; set; }
        [Required]
        [StringLength(CityMaxLength,MinimumLength =CityMinLength)]
        public string City { get; set; }
        [Required]
        [StringLength(ZipMaxLength,MinimumLength =ZipMinLength)]
        public string Zip { get; set; }
    }
}