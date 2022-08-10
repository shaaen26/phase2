using MSA.Phrase2.AmazingAPI.Services;
using MSA.Phrase2.AmazingAPI.Models;

namespace MSA.Phrase2.UnitTesting
{
    public class Tests
    {
        private PetServiceInterface petService;

        [SetUp]
        public void Setup()
        {
            petService = new PetServiceInMemory();

            // initially, add one new pet to the system
            Assert.NotNull(petService.GetAllPets());
            Assert.That(petService.GetAllPets().Count, Is.EqualTo(0));
            Pet newPet = new Pet() { Id = 10, Name = "test name", Type = "test type" };
            petService.AddNewPet(newPet);
        }

        
        /// <summary>
        /// test the functionality of get all method
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            Assert.That(petService.GetAllPets().Count, Is.EqualTo(1));
        }

        [Test]
        public void TestGetOnePet()
        {
            // currently no pets
            var pet = petService.GetPet(1);
            Assert.IsTrue(pet == null);
            
            // now the service contain one pet and the id starts from 0
            var pet1 = petService.GetPet(0);
            Assert.NotNull(pet1);
            Assert.That(pet1.Id, Is.EqualTo(0));
            Assert.That(pet1.Name, Is.EqualTo("test name"));
            Assert.That(pet1.Type, Is.EqualTo("test type"));
        }

        [Test]
        public void TestAddPet()
        {
            // add one pet again
            Pet newPet = new Pet() { Id = 10, Name = "test name1", Type = "test type1" };
            petService.AddNewPet(newPet);
            Assert.That(petService.GetAllPets().Count, Is.EqualTo(2));
            var pet1 = petService.GetPet(1);
            Assert.NotNull(pet1);
            Assert.That(pet1.Id, Is.EqualTo(1));
            Assert.That(pet1.Name, Is.EqualTo("test name1"));
            Assert.That(pet1.Type, Is.EqualTo("test type1"));
        }

        [Test]
        public void TestDeletePet()
        {
            petService.DeletePet(0);
            Assert.That(petService.GetAllPets().Count, Is.EqualTo(0));
            var pet1 = petService.GetPet(0);
            Assert.True(pet1 == null);
        
        }

        [Test]
        public void TestUpdatePet()
        {
            Pet updatePet = new Pet() { Id = 0, Name = "Update name", Type = "Update type" };
            petService.UpdatePet(updatePet);
            var pet1 = petService.GetPet(0);
            Assert.NotNull(pet1);
            Assert.That(pet1.Id, Is.EqualTo(0));
            Assert.That(pet1.Name, Is.EqualTo("Update name"));
            Assert.That(pet1.Type, Is.EqualTo("Update type"));
        }

    }
}