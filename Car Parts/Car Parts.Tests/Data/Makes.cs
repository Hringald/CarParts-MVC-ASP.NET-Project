namespace Car_Parts.Tests.Data
{
    using Car_Parts.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class Makes
    {
        public static IEnumerable<Make> TenMakes
           => Enumerable.Range(0, 10).Select(i => new Make {});
    }
}
