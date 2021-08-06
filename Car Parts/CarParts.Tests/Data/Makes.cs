namespace Car_Parts.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Car_Parts.Data.Models;

    public static class Makes
    {
        public static IEnumerable<Make> TenMakes
            => Enumerable.Range(0, 10).Select(i => new Make {});
    }
}