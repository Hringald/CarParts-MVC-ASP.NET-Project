namespace CarParts.Test.Data
{
    using CarParts.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Offers
    {
        public static IEnumerable<Offer> TenOffers
           => Enumerable.Range(0, 10).Select(i => new Offer { SellerId = "TestId" });
    }
}
