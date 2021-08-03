namespace Car_Parts.Areas.Admins.Models
{
    using Car_Parts.Models.Parts;
    using System.Collections.Generic;
    public class EditPartsViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; init; }
        public ICollection<PartViewModel> Parts { get; set; }
    }
}