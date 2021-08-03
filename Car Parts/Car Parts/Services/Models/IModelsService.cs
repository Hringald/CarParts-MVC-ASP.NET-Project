namespace Car_Parts.Services.Models
{
    using Car_Parts.Areas.Admins.Models;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Parts;
    using System.Collections.Generic;

    public interface IModelsService
    {
        public void AddModel(AddModelFormModel carModel, string adminId);
        public void EditModel(EditModelFormModel carModel, string adminId);
        public void DeleteModel(string modelId);
        public ICollection<PartCategoryViewModel> GetModels(string make);
        public ICollection<PartCategoryViewModel> GetMakes();
        public bool IsMakeValid(AddModelFormModel carModel);
        public bool DoesModelExist(AddModelFormModel carModel);
        public ICollection<EditModelsViewModel> GetEditModelInfo();
        public Model GetModelById(string modelId);
    }
}
