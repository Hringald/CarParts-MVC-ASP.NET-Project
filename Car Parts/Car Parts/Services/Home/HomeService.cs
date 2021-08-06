namespace Car_Parts.Services.Home
{
    using Car_Parts.Data;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Home;
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
