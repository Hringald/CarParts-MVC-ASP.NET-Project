namespace CarParts.Services.Home
{
    using CarParts.Models.Parts;
    using System.Collections.Generic;

    public interface IHomeService
    {
        public ICollection<PartCategoryViewModel> GetMakes();
    }
}
