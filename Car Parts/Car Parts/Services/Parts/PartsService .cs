namespace Car_Parts.Services.Parts
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Offers;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Makes;
    using System.Collections.Generic;
    using System.Linq;

    public class PartsService : IPartsService
    {
        private readonly CarPartsDbContext data;
        public PartsService(CarPartsDbContext data)
        {
            this.data = data;
        }
    }
}
