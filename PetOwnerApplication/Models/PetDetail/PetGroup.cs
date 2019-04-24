namespace PetOwnerApplication.Models.PetDetail
{
    using System.Collections.Generic;
    using static PetOwnerApplication.Models.Constants;

    public class PetGroup
    {
        public string GroupName { get; set; }
        public List<string> PetNames { get; set; }
    }
}