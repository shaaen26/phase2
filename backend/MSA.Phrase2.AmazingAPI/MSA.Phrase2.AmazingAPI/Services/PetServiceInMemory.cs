using MSA.Phrase2.AmazingAPI.Models;

namespace MSA.Phrase2.AmazingAPI.Services
{
    public class PetServiceInMemory : PetServiceInterface
    {
        List<Pet> Pets = new List<Pet>();
        int NextId = 0;

        public  List<Pet> GetAllPets() { return Pets; }
        
        public  Pet? GetPet(int id)
        {
            return Pets.FirstOrDefault(x => x.Id == id);
        }

        public  void AddNewPet(Pet pet)
        {
            pet.Id = NextId++;
            Pets.Add(pet);
        }

        public  void DeletePet(int id)
        {
            var pet = Pets.FirstOrDefault(x => x.Id == id);

            if (pet != null)
            {
                Pets.Remove(pet);
                return;
            }

        }
        

        public  void UpdatePet(Pet pet)
        {
            var index = Pets.FindIndex(p => p.Id == pet.Id);
            if (index == -1)
            {
                return;
            }

            Pets[index] = pet;
        }



    }
}
