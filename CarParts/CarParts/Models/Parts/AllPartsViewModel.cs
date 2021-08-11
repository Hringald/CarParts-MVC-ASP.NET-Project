namespace CarParts.Models.Parts
{
    using System.Collections.Generic;

    public class AllPartsViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public const int PartsPerPage = 6;     
        public string SearchTerm { get; set; }
        public int TotalParts { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public ICollection<PartViewModel> Parts { get; set; }
    }
}