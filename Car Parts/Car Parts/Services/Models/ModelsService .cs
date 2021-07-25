namespace Car_Parts.Services.Models
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Makes;
    using System.Collections.Generic;
    using System.Linq;

    public class ModelsService : IModelsService
    {
        private readonly CarPartsDbContext data;
        public ModelsService(CarPartsDbContext data)
        {
            this.data = data;
        }

        public void AddModel(AddModelFormModel carModel, string adminId)
        {
            var make = this.data.Makes.FirstOrDefault(m => m.Id == carModel.MakeId);

            var modelModel = new Model
            {
                Name = carModel.Name,
                ImageUrl = carModel.ImageUrl,
                Make = make,
                AdminId = adminId
            };

            make.Models.Add(modelModel);
            this.data.Models.Add(modelModel);
            this.data.SaveChanges();
        }

        public bool DoesModelExist(AddModelFormModel carModel)
        {
            var make = this.data.Makes.FirstOrDefault(m => m.Id == carModel.MakeId);

            return this.data
              .Models
              .Where(m => m.Make.Name == make.Name)
              .Any(m => m.Name == carModel.Name);
        }

        public ICollection<PartCategoryViewModel> GetMakes()
            => this.data
              .Makes
              .Select(p => new PartCategoryViewModel
              {
                  Id = p.Id,
                  Name = p.Name
              }).ToList();

        public ICollection<PartCategoryViewModel> GetModels(string make)
            => this.data
            .Models
            .Where(m => m.Make.Name == make)
            .Select(m => new PartCategoryViewModel
            {
                Id = m.Id,
                Name = m.Name,
                ImageUrl = m.ImageUrl
            }).ToList();

        public bool IsMakeValid(AddModelFormModel carModel)
            => this.data
            .Makes
            .Any(m => m.Id == carModel.MakeId);

    }
}
