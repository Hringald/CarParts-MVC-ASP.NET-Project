namespace Car_Parts.Services.Admins
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Makes;
    using System.Linq;

    public class MakesService : IMakesService
    {
        private readonly CarPartsDbContext data;
        public MakesService(CarPartsDbContext data)
        {
            this.data = data;
        }

        public void AddMake(AddMakeFormModel makeModel,string adminId)
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
    }
}
