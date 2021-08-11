namespace CarParts.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants.Part;
    public class Part
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string MakeId { get; set; }
        public Make Make { get; set; }
        public string ModelId { get; set; }
        public Model Model { get; set; }
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
        [Range(QuantityMinValue,QuantityMaxValue)]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Range(typeof(decimal), "0.01", DecimalMaxValue)]
        public decimal Price { get; set; }
        public string SellerId { get; set; }
        public ApplicationUser Seller { get; set; }
    }
}
