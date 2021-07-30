namespace Car_Parts.Services.Parts
{
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Offers;
    using Car_Parts.Models.Parts;
    using System.Collections.Generic;

    public interface IPartsService
    {
        public void AddPart(AddPartFormModel part, string sellerId);
        public Part GetPartById(string partId);
        public ICollection<PartCategoryViewModel> GetMakes();
        public ICollection<PartCategoryViewModel> GetCategories();
        public ICollection<PartCategoryViewModel> GetModels(string make);
        public bool IsMakeValid(string makeId);
        public bool IsModelValid(string ModelId);
        public bool IsCategoryValid(string CategoryId);
        public AddOfferFormModel GetPartInfo(string partId);
        public EditPartFormModel GetEditPartInfo(string partId);
        public void AddOffer(AddOfferFormModel offerModel);
        public void EditPart(EditPartFormModel part);


        public bool isMakeValid(string makeName);
        public bool isModelValid(string modelId);
        public bool isCategoryValid(string categoryId);

        public void Delete(string partId);

        public ICollection<PartViewModel> GetMyParts(string userId);
    }
}
