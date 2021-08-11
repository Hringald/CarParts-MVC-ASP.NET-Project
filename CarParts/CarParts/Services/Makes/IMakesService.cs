namespace CarParts.Services.Makes
{
    using CarParts.Data.Models;
    using CarParts.Areas.Admin.Views.Models;
    using CarParts.Models.Parts;
    public interface IMakesService
    {
        public void DeleteMake(string makeId);
        public void AddMake(AddMakeFormModel makeModel, string adminId);
        public bool MakeExists(AddMakeFormModel makeModel);
        public Make GetMakeById(string id);
        public void EditMake(EditMakeFormModel makeModel, string adminId);
    }
}
