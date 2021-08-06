namespace Car_Parts.Services.Makes
{
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Admins;
    using Car_Parts.Models.Parts;
    public interface IMakesService
    {
        public void DeleteMake(string makeId);
        public void AddMake(AddMakeFormModel makeModel, string adminId);
        public bool MakeExists(AddMakeFormModel makeModel);
        public Make GetMakeById(string id);
        public void EditMake(EditMakeFormModel makeModel, string adminId);
    }
}
