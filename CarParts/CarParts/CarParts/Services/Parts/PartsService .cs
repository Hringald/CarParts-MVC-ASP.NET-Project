namespace CarParts.Services.Parts
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using CarParts.Models.Offers;
    using CarParts.Models.Parts;
    using CarParts.Services.Makes;
    using System.Collections.Generic;
    using System.Linq;

    public class PartsService : IPartsService
    {
        private readonly CarPartsDbContext data;
        private readonly IMakesService makes;
        public PartsService(CarPartsDbContext data, IMakesService makes)
        {
            this.data = data;
            this.makes = makes;
        }

        public ICollection<PartCategoryViewModel> GetCategories()
           => this.data
                .Categories
                .Select(p => new PartCategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();

        public Make GetMake(string make)
              => this.data
                  .Makes
                  .FirstOrDefault(m => m.Name == make);

        public ICollection<PartCategoryViewModel> GetMakes()
            => this.data.Makes
             .Select(m => new PartCategoryViewModel
             {
                 Id = m.Id,
                 Name = m.Name,
                 ImageUrl = m.ImageUrl
             })            
            .OrderByDescending(m => m.Name)
            .ToList();

        public ICollection<PartCategoryViewModel> GetModels(string make)
          =>
          this.data
          .Models
          .Where(m => m.Make.Name == make)
          .Select(p => new PartCategoryViewModel
          {
              Id = p.Id,
              Name = p.Name
          }).ToList();

        public bool IsCategoryValid(string CategoryId)
        => this.data.Categories.Any(c => c.Id == CategoryId);

        public bool IsModelValid(string ModelId)
        => this.data.Models.Any(m => m.Id == ModelId);

        public bool IsMakeValid(string makeName)
        => this.data.Makes.Any(m => m.Name == makeName);

        public void AddPart(AddPartFormModel part, string sellerId)
        {
            var make = this.data.Makes.FirstOrDefault(m => m.Name == part.MakeName);
            var model = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var partModel = new Part
            {
                Name = part.Name,
                ImageUrl = part.ImageUrl,
                CategoryId = part.CategoryId,
                Category = category,
                MakeId = part.MakeId,
                Make = make,
                ModelId = part.ModelId,
                Model = model,
                Description = part.Description,
                Quantity = part.Quantity,
                Price = part.Price,
                SellerId = sellerId,
            };

            this.data.Parts.Add(partModel);
            this.data.SaveChanges();
        }

        public AddOfferFormModel GetPartInfo(string partId)
        {
            var part = this.GetPartById(partId);

            var make = this.makes.GetMakeById(part.MakeId);

            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var partModel = new AddOfferFormModel
            {
                Id = part.Id,
                Description = part.Description,
                MakeName = make.Name,
                CategoryName = category.Name,
                Price = part.Price.ToString("f2"),
                ImageUrl = part.ImageUrl,
                Name = part.Name,
                Quantity = part.Quantity
            };

            return partModel;
        }

        public void AddOffer(AddOfferFormModel offerModel)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == offerModel.Id);

            var seller = this.data.Users.FirstOrDefault(u => u.Id == part.SellerId);

            var offer = new Offer
            {
                Name = offerModel.BuyerName,
                Address = offerModel.Address,
                City = offerModel.City,
                Email = offerModel.Email,
                Phone = offerModel.Phone,
                ZipCode = int.Parse(offerModel.Zip),
                Part = part,
                PartId = part.Id,
                SellerId = seller.Id
            };

            this.data.Offers.Add(offer);
            this.data.SaveChanges();
        }

        public EditPartFormModel GetEditPartInfo(string partId)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            var make = this.data.Makes.FirstOrDefault(m => m.Id == part.MakeId);
            var model = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var categories = this.GetCategories();

            var partModel = new EditPartFormModel
            {
                Id = part.Id,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                MakeName = make.Name,
                ModelName = model.Name,
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                CategoryId = category.Id,
                Categories = categories,
            };

            return partModel;
        }

        public void EditPart(EditPartFormModel part)
        {
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var partToUpdate = this.data.Parts.FirstOrDefault(p => p.Id == part.Id);


            partToUpdate.Name = part.Name;
            partToUpdate.ImageUrl = part.ImageUrl;
            partToUpdate.Price = part.Price;
            partToUpdate.Quantity = part.Quantity;
            partToUpdate.Description = part.Description;
            partToUpdate.Category = category;

            this.data.SaveChanges();
        }

        public bool isMakeValid(string makeName)
        => this.data
            .Makes
            .Any(m => m.Name == makeName);

        public bool isModelValid(string modelId)
        => this.data
            .Models
            .Any(m => m.Name == modelId);

        public bool isCategoryValid(string categoryId)
            => this.data
            .Categories
            .Any(c => c.Id == categoryId);

        public void Delete(string partId)
        {
            var part = this.GetPartById(partId);

            this.data.Parts.Remove(part);
            this.data.SaveChanges();
        }

        public ICollection<PartViewModel> GetMyParts(string userId)
        {
           return this.data.Parts
                  .Where(p => p.SellerId == userId)
                  .Select(p => new PartViewModel
                  {
                      Id = p.Id,
                      Name = p.Name,
                      MakeName = p.Make.Name,
                      CategoryName = p.Category.Name,
                      Price = p.Price.ToString("f2"),
                      Quantity = p.Quantity
                  })
                  .OrderByDescending(p=>p.MakeName)
                  .ToList();
        }


        public Part GetPartById(string partId)
           => this.data
                  .Parts
                  .FirstOrDefault(p => p.Id == partId);
    }
}
