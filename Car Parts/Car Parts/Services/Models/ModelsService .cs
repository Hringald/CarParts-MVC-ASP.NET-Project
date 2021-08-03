namespace Car_Parts.Services.Models
{
    using Car_Parts.Areas.Admins.Models;
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Makes;
    using System.Collections.Generic;
    using System.Linq;

    public class ModelsService : IModelsService
    {
        private readonly CarPartsDbContext data;
        private readonly IMakesService makes;
        public ModelsService(CarPartsDbContext data,IMakesService makes)
        {
            this.data = data;
            this.makes = makes;
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

        public void DeleteModel(string modelId)
        {
            var model = this.GetModelById(modelId);

            this.data.Remove(model);
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

        public void EditModel(EditModelFormModel carModel, string adminId)
        {
            var model = this.GetModelById(carModel.Id);
            var make = this.makes.GetMakeById(carModel.MakeId);

            model.AdminId = adminId;
            model.Make = make;
            model.ImageUrl = carModel.ImageUrl;
            model.MakeId = carModel.MakeId;
            model.Name = carModel.Name;

            this.data.SaveChanges();
        }

        public ICollection<EditModelsViewModel> GetEditModelInfo()
              => this.data
                 .Models
                 .Select(m => new EditModelsViewModel
                 {
                     Id = m.Id,
                     MakeName = m.Make.Name,
                     ModelName = m.Name
                 })
                 .OrderByDescending(m => m.MakeName)
                 .ThenByDescending(m => m.ModelName)
                 .ToList();

        public ICollection<PartCategoryViewModel> GetMakes()
            => this.data
              .Makes
              .Select(p => new PartCategoryViewModel
              {
                  Id = p.Id,
                  Name = p.Name
              }).ToList();

        public Model GetModelById(string modelId)
            => this.data
               .Models.FirstOrDefault(m=>m.Id==modelId);

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
