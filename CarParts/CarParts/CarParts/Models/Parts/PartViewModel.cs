namespace CarParts.Models.Parts
{
    public class PartViewModel
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public bool IsSeller { get; set; }
    }
}