namespace CarParts.Services.Offers
{
    using CarParts.Models.Offers;
    using System.Collections.Generic;

    public interface IOffersService
    {
        public ICollection<OffersViewModel> GetOffers(string userId);
        public OfferInfoViewModel GetOfferInfo(string offerId);
        public void Sell(string partId, string offerId);
        public void Decline(string offerId);
    }
}
