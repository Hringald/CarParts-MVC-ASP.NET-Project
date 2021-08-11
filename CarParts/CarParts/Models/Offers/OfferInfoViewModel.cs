namespace CarParts.Models.Offers
{
    using CarParts.Models.Parts;
    public class OfferInfoViewModel : PartViewModel
    {
        public string OfferId { get; set; }
        public string BuyerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}