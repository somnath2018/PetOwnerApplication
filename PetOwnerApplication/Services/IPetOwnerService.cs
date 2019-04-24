namespace PetOwnerApplication.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.PetDetail;
    using static PetOwnerApplication.Models.Constants;

    public interface IPetOwnerService
    {
        List<PetGroup> GetPetDetailsByGenderGroup(PetType petType);
    }
}
