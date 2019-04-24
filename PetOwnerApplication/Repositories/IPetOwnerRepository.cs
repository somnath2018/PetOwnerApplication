namespace PetOwnerApplication.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.PetDetail;

    public interface IPetOwnerRepository
    {
        List<PetOwnerPerson> GetAllPetOwnerDetails();
    }
}
