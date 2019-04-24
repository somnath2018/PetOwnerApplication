namespace PetOwnerApplication.Tests.Services
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using PetOwnerApplication.Models;
    using PetOwnerApplication.Repositories;
    using PetOwnerApplication.Services;
    using PetOwnerApplication.Tests.MockData;
    using static PetOwnerApplication.Models.Constants;

    [TestClass]
    public class PetOwnerServiceTest
    {
        [TestMethod]
        public void GetPetsByOwnerGenderNotNull()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethodAttribute]
        public void GetPetsByOwnerGenderGroupCount()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);

            // Assert
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethodAttribute]
        public void GetPetsByOwnerGenderEachGenderGroupAvailable()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);

            // Assert
            Assert.IsTrue(result.Any(r => r.GroupName == Constants.Gender.Male.ToString()));
            Assert.IsTrue(result.Any(r => r.GroupName == Constants.Gender.Female.ToString()));
        }

        [TestMethodAttribute]
        public void GetPetsByOwnerGenderGenderGroupCount()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);

            // Assert
            Assert.AreEqual(result.Count(r => r.GroupName == Constants.Gender.Male.ToString()), 1);
            Assert.AreEqual(result.Count(r => r.GroupName == Constants.Gender.Female.ToString()), 1);
        }

        [DataRowAttribute(0)]
        [DataRowAttribute(1)]
        [DataRowAttribute(2)]
        [DataTestMethodAttribute]
        public void TestOrderSequenceOfPetsForMaleOwner(int index)
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);
            Assert.IsNotNull(result);
            var petNames = result.Where(r => r.GroupName == Constants.Gender.Male.ToString()).SelectMany(p => p.PetNames);
            var expectedResult = mockProvider.GetMockPetGroup().Where(r => r.GroupName == Constants.Gender.Male.ToString()).SelectMany(m => m.PetNames);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(petNames.ElementAt(index), expectedResult.ElementAt(index));
        }

        [TestMethodAttribute]
        public void TestEmptyPetListExistsForSingleGroup()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerSingleNullPetArrayResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);
            var maleGroupPetNames = result.Where(r => r.GroupName == Constants.Gender.Male.ToString()).SelectMany(m => m.PetNames);

            // Assert
            Assert.AreEqual(maleGroupPetNames.Count(), 0);
        }

        [TestMethodAttribute]
        public void TestEmptyPetListExistsForAllGroup()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockRepository = new Mock<IPetOwnerRepository>();
            mockRepository.Setup(p => p.GetAllPetOwnerDetails()).Returns(mockProvider.GetMockPetOwnerBothNullPetArrayResult());
            var petService = new PetOwnerService(mockRepository.Object);

            // Act
            var result = petService.GetPetDetailsByGenderGroup(PetType.Cat);
            var maleGroupPetNames = result.Where(r => r.GroupName == Constants.Gender.Male.ToString()).SelectMany(m => m.PetNames);
            var femaleGroupPetNames = result.Where(r => r.GroupName == Constants.Gender.Female.ToString()).SelectMany(m => m.PetNames);

            // Assert
            Assert.AreEqual(maleGroupPetNames.Count(), 0);
            Assert.AreEqual(femaleGroupPetNames.Count(), 0);
        }
    }
}
