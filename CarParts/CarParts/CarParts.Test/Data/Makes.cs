namespace CarParts.Test.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using CarParts.Data.Models;
    public static class Makes
    {
        public static IEnumerable<Make> TenMakes
            => Enumerable.Range(0, 10).Select(i => new Make { });
    }
}