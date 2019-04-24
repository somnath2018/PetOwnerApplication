namespace PetOwnerApplication.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.PetDetail;
    using Repositories;
    using Utilities;
    using static PetOwnerApplication.Models.Constants;

    public class PetOwnerService : IPetOwnerService
    {
        private readonly IPetOwnerRepository _petRepository;

        public PetOwnerService(IPetOwnerRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public List<PetGroup> GetPetDetailsByGenderGroup(PetType petType)
        {
            try
            {
                var petOwners = _petRepository.GetAllPetOwnerDetails();
                var petGroups = new List<PetGroup>();
                if (petOwners.Any())
                {
                    petGroups = petOwners.GroupBy(p => p.Gender)
                        .Select(p => new PetGroup
                        {
                            GroupName = p.Key.ToString(),
                            PetNames = p.SelectManyExceptNull(po => po.Pets)
                                .Where(c => c.Type == petType)
                                .Select(c => c.Name)
                                .Distinct()
                                .OrderBy(c => c)
                                .ToList()
                        }).ToList();

                }

                return petGroups;

            }
            catch (Exception ex)
            {
                Logging.LogError(ex.ToString());
                throw;
            }
        }
    }
}