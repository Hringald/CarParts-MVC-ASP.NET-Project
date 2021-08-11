namespace CarParts.Test.Data
{
    using CarParts.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Admins
    {
        public static IEnumerable<Admin> TenAdmins
    => Enumerable.Range(0, 10).Select(i => new Admin { });
    }
}
