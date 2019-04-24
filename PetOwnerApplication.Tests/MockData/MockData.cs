namespace PetOwnerApplication.Tests.MockData
{
    using System.Collections.Generic;
    using Models.PetDetail;
    using PetOwnerApplication.Models;
    using static PetOwnerApplication.Models.Constants;

    public class MockProvider
    {
        #region Gender Pets
        
        public List<Pet> GetMaleMockPetResult()
        {
            return new List<Pet>
            {
                new Pet { Name = "Garfield", Type = PetType.Cat },
                new Pet { Name = "Fido", Type = PetType.Dog },
                new Pet { Name = "Tom", Type = PetType.Cat },
                new Pet { Name = "Simba", Type = PetType.Cat },
                new Pet { Name = "Nemo", Type = PetType.Fish },
                new Pet { Name = "Sam", Type = PetType.Dog },
                new Pet { Name = "Garfield", Type = PetType.Cat}
            };
        }
        public List<Pet> GetFemaleMockPetResult()
        {
            return new List<Pet>
            {
                new Pet { Name = "Rosy", Type = PetType.Cat },
                new Pet { Name = "Fido", Type = PetType.Dog },
                new Pet { Name = "Lucy", Type = PetType.Cat },
                new Pet { Name = "Sweetie", Type = PetType.Cat },
                new Pet { Name = "Nemo", Type = PetType.Fish },
                new Pet { Name = "Sam", Type = PetType.Dog },
                new Pet { Name = "Rosy", Type = PetType.Cat }
            };
        }
        #endregion

        #region PetOwner Setup
       public List<PetOwnerPerson> GetMockPetOwnerResult()
        {
            return new List<PetOwnerPerson>
            {
                new PetOwnerPerson { Name = "Bob", Gender = Constants.Gender.Male, Age = 23, Pets = GetMaleMockPetResult() },
                new PetOwnerPerson { Name = "Jennifer", Gender = Constants.Gender.Female, Age = 18, Pets = GetFemaleMockPetResult() }
            };
        }
        
        public List<PetOwnerPerson> GetMockPetOwnerSingleNullPetArrayResult()
        {
            return new List<PetOwnerPerson>
            {
                new PetOwnerPerson { Name = "Bob", Gender = Constants.Gender.Male, Age = 23, Pets = null },
                new PetOwnerPerson { Name = "Jennifer", Gender = Constants.Gender.Female, Age = 18, Pets = GetFemaleMockPetResult() }
            };
        }
        
        public List<PetOwnerPerson> GetMockPetOwnerBothNullPetArrayResult()
        {
            return new List<PetOwnerPerson>
            {
                new PetOwnerPerson { Name = "Bob", Gender = Constants.Gender.Male, Age = 23, Pets = null },
                new PetOwnerPerson { Name = "Jennifer", Gender = Constants.Gender.Female, Age = 18, Pets = null }
            };
        }
        
        #endregion

        #region Mock PetGroup Setup
        public List<PetGroup> GetMockPetGroup()
        {
            return new List<PetGroup>
            {
                new PetGroup { GroupName = "Male", PetNames = new List<string> { "Garfield", "Simba", "Tom" } },
                new PetGroup { GroupName = "Female", PetNames = new List<string> { "Lucy", "Rosy", "Sweetie" } },
            };
        }
        
       public List<PetGroup> GetMockPetGroupWithError()
        {
            return new List<PetGroup>
            {
                new PetGroup { GroupName = "Male", PetNames = null },
                new PetGroup { GroupName = "Female", PetNames = null },
            };
        }
        public List<PetGroup> GetMockPetGroupWithNull()
        {
            return null;
        }
        #endregion
    }
}
