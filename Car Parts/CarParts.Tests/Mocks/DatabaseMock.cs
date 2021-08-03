namespace Car_Parts.Tests.Mocks
{
    using Car_Parts.Data;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class DatabaseMock
    {
        public static CarPartsDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<CarPartsDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new CarPartsDbContext(dbContextOptions);
            }
        }
    }
}
