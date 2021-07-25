namespace Car_Parts.Services.Home
{
    using Car_Parts.Models.Admins;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public interface IHomeService
    {
        public ICollection<PartCategoryViewModel> GetMakes();
    }
}
