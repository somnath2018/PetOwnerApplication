namespace PetOwnerApplication.Tests.Repositories
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using PetOwnerApplication.Repositories;
    using PetOwnerApplication.Utilities.Caching;

    [TestClass]
    public class PetOwnerRepositoryTest
    {
        [TestMethod]
        public void GetPetsByOwnerGenderNotNull()
        {
            // Arrange
            var mockCaching = new Mock<ICaching>();
            var petRepository = new PetOwnerRepository(mockCaching.Object);

            // Act
            var result = petRepository.GetAllPetOwnerDetails();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 6);
        }
    }
}
