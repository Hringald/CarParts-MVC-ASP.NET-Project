namespace Car_Parts.Services.Makes
{
    using Car_Parts.Models.Parts;
    public interface IMakesService
    {
        public void AddMake(AddMakeFormModel makeModel, string adminId);
        public bool MakeExists(AddMakeFormModel makeModel);
    }
}
