using MSA.Phrase2.AmazingAPI.Models;

namespace MSA.Phrase2.AmazingAPI.Services
{
    public static class PetService
    {
        static List<Pet> Pets = new List<Pet>();
        static int NextId = 0;

        public static List<Pet> GetAllPets() { return Pets; }

        public static int GetNextId() { return NextId; }

        
        public static Pet? GetPet(int id)
        {
            return Pets.FirstOrDefault(x => x.Id == id);
        }

        public static void AddNewPet(Pet pet)
        {
            pet.Id = NextId++;
            Pets.Add(pet);
        }

        public static void DeletePet(int id)
        {
            var pet = Pets.FirstOrDefault(x => x.Id == id);

            if (pet != null)
            {
                Pets.Remove(pet);
                return;
            }

        }
        

        public static void UpdatePet(Pet pet)
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
