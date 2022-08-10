using MSA.Phrase2.AmazingAPI.Services;
using MSA.Phrase2.AmazingAPI.Models;
using MSA.Phrase2.AmazingAPI.Controllers;
using NSubstitute;

namespace MSA.Phrase2.UnitTesting
{
    public class UnitTestController
    {
        private PetServiceInterface petService;
        private PetController petController;

        [SetUp]
        public void Setup()
        {
            petService = Substitute.For<PetServiceInterface>();
            petController = new PetController(petService);

            
        }

        [Test]
        public void TestGetAll()
        {
            petController.GetAll();
            petService.Received().GetAllPets();
        }

        [Test]
        public void TestGetSpecifiedPet()
        {
            petController.Get(10);
            petService.Received().GetPet(10);
        }

        [Test]
        public void TestAddPet()
        {
            Pet pet = new Pet() { Id=10, Name="testname", Type="typename"};
            petController.AddPet(pet);
            petService.Received().AddNewPet(pet);
        }

        [Test]
        public void TestUpdatePet()
        {
            Pet pet = new Pet() { Id = 10, Name = "testname", Type = "typename" };
            Pet pet1 = new Pet() { Id = 10, Name = "updatename", Type = "updatename" };
            petService.GetPet(10).Returns(pet);
            petController.UpdatePetInfo(10, pet1);
            petService.Received().UpdatePet(pet1);
        }

        [Test]
        public void TestDeletePet()
        {
            Pet pet = new Pet() { Id = 10, Name = "testname", Type = "typename" };
            petService.GetPet(10).Returns(pet);
            petController.DeletePet(10);
            petService.Received().DeletePet(10);
        }
    }
}
