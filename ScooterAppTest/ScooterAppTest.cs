using Moq;
using ScooterApp.Models;
using ScooterApp.Services;
using ScooterApp.Services.Interfaces;


namespace ScooterApp1Test
{
    [TestClass]
    public class ScooterAppTest
    {

        [TestMethod]
        public void HireScooter_WhenAPersonHasHiredAScooter_ThrowsException()
        {
            // Arrange
            var person = new Person()
            {
                Id = 1,
                Name = "John Doe",
                HasHiredScooter = true
            };

            var scooter = new Scooter()
            {
                Id = 1,
                IsHired = true,
                HiredBy = 2
            };

            var mockDatabaseService = new Mock<IDatabaseService>();
            mockDatabaseService.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(person);
            mockDatabaseService.Setup(x => x.GetScooter(It.IsAny<int>())).Returns(scooter);
            var scooterService = new ScooterServices(mockDatabaseService.Object);

            //Act


            //Assert
            var ex = Assert.ThrowsException<Exception>(() => scooterService.HireScooter(1, 1));
            Assert.AreEqual("Person already has hired a scooter", ex.Message);

        }


        [TestMethod]
        public void HireScooter_WhenAPersonHasAlreadyHiredThisScooter_ThrowsException()
        {
            // Arrange
            var person = new Person()
            {
                Id = 1,
                Name = "John Doe",
                HasHiredScooter = true
            };

            var scooter = new Scooter()
            {
                Id = 1,
                IsHired = true,
                HiredBy = 1
            };

            var mockDatabaseService = new Mock<IDatabaseService>();
            mockDatabaseService.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(person);
            mockDatabaseService.Setup(x => x.GetScooter(It.IsAny<int>())).Returns(scooter);
            var scooterService = new ScooterServices(mockDatabaseService.Object);

            //Act


            //Assert
            var ex = Assert.ThrowsException<Exception>(() => scooterService.HireScooter(1, 1));
            Assert.AreEqual("Person already has hired This scooter", ex.Message);

        }


        [TestMethod]
        public void HireScooter_WhenScooterIsAvailableAndPersonHasNotHiredScooter_ReturnsTrue()
        {
            // Arrange
            var person = new Person()
            {
                Id = 1,
                Name = "John Doe",
                HasHiredScooter = false
            };

            var scooter = new Scooter()
            {
                Id = 1,
                IsHired = false
            };

            var mockDatabaseService = new Mock<IDatabaseService>();
            mockDatabaseService.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(person);
            mockDatabaseService.Setup(x => x.GetScooter(It.IsAny<int>())).Returns(scooter);
            var scooterService = new ScooterServices(mockDatabaseService.Object);

            //Act
            var canHire = scooterService.HireScooter(1, 1);

            //Assert
            Assert.AreEqual(canHire, true);

        }

        [TestMethod]
        public void HireScooter_WhenScooterIsNotAvailableAndPersonHasNotHiredScooter_ThrowsException()
        {
            // Arrange
            var person = new Person()
            {
                Id = 1,
                Name = "John Doe",
                HasHiredScooter = false
            };

            var scooter = new Scooter()
            {
                Id = 1,
                IsHired = true,
                HiredBy = 2
            };

            var mockDatabaseService = new Mock<IDatabaseService>();
            mockDatabaseService.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(person);
            mockDatabaseService.Setup(x => x.GetScooter(It.IsAny<int>())).Returns(scooter);
            var scooterService = new ScooterServices(mockDatabaseService.Object);

            //Act


            //Assert
            var ex = Assert.ThrowsException<Exception>(() => scooterService.HireScooter(1, 1));
            Assert.AreEqual("Scooter is not available because is is already hired", ex.Message);
        }
    }
}