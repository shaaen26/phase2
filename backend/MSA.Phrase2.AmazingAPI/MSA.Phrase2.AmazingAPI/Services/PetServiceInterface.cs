

using MSA.Phrase2.AmazingAPI.Models;

namespace MSA.Phrase2.AmazingAPI.Services
{
    public interface PetServiceInterface
    {
        List<Pet> GetAllPets();

        Pet? GetPet(int id);

        void AddNewPet(Pet pet);

        void DeletePet(int id);

        void UpdatePet(Pet pet);
    }
}
