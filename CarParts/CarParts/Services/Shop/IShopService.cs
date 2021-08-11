namespace CarParts.Services.Shop
{
    using CarParts.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public interface IShopService
    {
        public ICollection<PartCategoryViewModel> GetCategories();
        public AllPartsViewModel ShopPageRender([FromQuery] AllPartsViewModel query, string sellerId);
    }
}
