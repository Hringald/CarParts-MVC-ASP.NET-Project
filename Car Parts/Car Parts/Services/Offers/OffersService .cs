namespace Car_Parts.Services.Offers
{
    using Car_Parts.Data;
    using Car_Parts.Models.Offers;
    using System.Collections.Generic;
    using System.Linq;

    public class OffersService : IOffersService
    {
        private readonly CarPartsDbContext data;
        public OffersService(CarPartsDbContext data)
        {
            this.data = data;
        }

        public void Decline(string offerId)
        {
            var offer = this.data.Offers.FirstOrDefault(o => o.Id == offerId);
            this.data.Offers.Remove(offer);
            this.data.SaveChanges();
        }

        public OfferInfoViewModel GetOfferInfo(string offerId)
        {
            var offer = this.data.Offers.FirstOrDefault(o => o.Id == offerId);

            var part = this.data.Parts.FirstOrDefault(p => p.Id == offer.PartId);

            var partCategory = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);
            var partMake = this.data.Makes.FirstOrDefault(m => m.Id == part.MakeId);
            var partModel = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);

            var infoModel = new OfferInfoViewModel
            {
                Id = part.Id,
                OfferId = offer.Id,
                Address = offer.Address,
                BuyerName = offer.Name,
                City = offer.City,
                Email = offer.Email,
                Zip = offer.ZipCode.ToString(),
                Phone = offer.Phone,
                CategoryName = partCategory.Name,
                ImageUrl = part.ImageUrl,
                Description = part.Description,
                MakeName = partMake.Name,
                ModelName = partModel.Name,
                Price = part.Price.ToString("f2"),
                Name = part.Name,
                Quantity = part.Quantity,
            };

            return infoModel;
        }

        public ICollection<OffersViewModel> GetOffers(string userId)
        {
            var offers = this.data.Offers.Where(o => o.SellerId == userId);

            var offersModel = offers.Select(o => new OffersViewModel
            {
                Id = o.Id,
                PartName = o.Part.Name,
                BuyerName = o.Name,
                Price = o.Part.Price.ToString("f2"),
                Quantity = o.Part.Quantity
            }).ToList();

            return offersModel;
        }

        public void Sell(string partId, string offerId)
        {
            var offer = this.data.Offers.FirstOrDefault(o => o.Id == offerId);
            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            if (part.Quantity - 1 <= 0)
            {
                this.data.Remove(part);
            }
            else
            {
                part.Quantity -= 1;
            }

            this.data.Offers.Remove(offer);
            this.data.SaveChanges();
        }
    }
}
