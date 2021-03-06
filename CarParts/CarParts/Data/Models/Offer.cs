namespace CarParts.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Offer;
    public class Offer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string PartId { get; set; }
        public Part Part { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string SellerId { get; set; }
        public ApplicationUser Seller { get; set; }
    }
}