using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;

namespace CarFactoryAPI_test
{
    public class OwnerRepositoryTests
    {
        private Mock<FactoryContext> factoryContextMock;
        private OwnerRepository ownerRepository;

        public OwnerRepositoryTests()
        {
            // Create Mock of dependencies
            factoryContextMock = new Mock<FactoryContext>();

            // use fake object as dependency
            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }



        [Fact]
        [Trait("Author", "Sarah")]
        public void AddOwner_InvalidId_ReturnsFalse()
        {
            // Arrange
            Owner ownerToAdd = new Owner { Id = -1, Name = "Invalid Owner" };

            // Act 
            bool result = ownerRepository.AddOwner(ownerToAdd);

            // Assert
            Assert.False(result);
        }


        [Fact]
        [Trait("Author", "Sarah")]

        public void GetOwnerById_AskForOwner10_ReturnOwner()
        {
            // Arrange
            // Build the mock Data
            List<Owner> owners = new List<Owner>() { new Owner() { Id = 10 } };

            // setup called DbSets
            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

            // Act 
            Owner owner = ownerRepository.GetOwnerById(10);

            // Assert
            Assert.NotNull(owner);
        }
    }
}
