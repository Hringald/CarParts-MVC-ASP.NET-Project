namespace CarParts.Services.Makes
{
    using CarParts.Data;
    using CarParts.Data.Models;
    using CarParts.Areas.Admin.Views.Models;
    using CarParts.Models.Parts;
    using CarParts.Services.Makes;
    using System.Linq;

    public class MakesService : IMakesService
    {
        private readonly CarPartsDbContext data;
        public MakesService(CarPartsDbContext data)
        {
            this.data = data;
        }

        public void AddMake(AddMakeFormModel makeModel, string adminId)
        {
            var make = new Make
            {
                Name = makeModel.Name,
                ImageUrl = makeModel.ImageUrl,
                AdminId = adminId,
            };

            this.data.Makes.Add(make);
            this.data.SaveChanges();
        }

        public bool MakeExists(AddMakeFormModel makeModel)
            => this.data.Makes.Any(m => m.Name == makeModel.Name);

        public Make GetMakeById(string id)
            => this.data
                .Makes
                .FirstOrDefault(m => m.Id == id);

        public void DeleteMake(string makeId)
        {
            var make = this.GetMakeById(makeId);

            this.data.Makes.Remove(make);

            this.data.SaveChanges();
        }

        public void EditMake(EditMakeFormModel makeModel, string adminId)
        {
            var make = this.GetMakeById(makeModel.Id);

            make.AdminId = adminId;
            make.Name = makeModel.Name;
            make.ImageUrl = makeModel.ImageUrl;

            this.data.SaveChanges();
        }
    }
}
