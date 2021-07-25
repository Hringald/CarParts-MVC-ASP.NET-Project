namespace Car_Parts.Services.Home
{
    using Car_Parts.Models.Parts;
    using System.Collections.Generic;

    public interface IHomeService
    {
        public ICollection<PartCategoryViewModel> GetMakes();
    }
}
