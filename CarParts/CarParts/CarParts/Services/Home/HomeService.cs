namespace CarParts.Services.Home
{
    using CarParts.Data;
    using CarParts.Models.Parts;
    using CarParts.Services.Home;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly CarPartsDbContext data;
        public HomeService(CarPartsDbContext data)
        {
            this.data = data;
        }

        public ICollection<PartCategoryViewModel> GetMakes()
            =>this.data.Makes
                .Select(m => new PartCategoryViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                }).ToList();
        
    }
}
