namespace PetOwnerApplication.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MockData;
    using Moq;
    using PetOwnerApplication.Controllers;
    using PetOwnerApplication.Services;
    using static PetOwnerApplication.Models.Constants;

    [TestClass]
    public class PetControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var mockProvider = new MockProvider();
            var mockService = new Mock<IPetOwnerService>();
            mockService.Setup(p => p.GetPetDetailsByGenderGroup(PetType.Cat)).Returns(mockProvider.GetMockPetGroup());
            PetController controller = new PetController(mockService.Object);

            // Act
            var result = controller.GetPet();

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
