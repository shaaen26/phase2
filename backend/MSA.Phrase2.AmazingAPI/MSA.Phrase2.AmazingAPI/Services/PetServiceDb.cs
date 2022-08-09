using MSA.Phrase2.AmazingAPI.Data;
using MSA.Phrase2.AmazingAPI.Models;


namespace MSA.Phrase2.AmazingAPI.Services
{
    public class PetServiceDb : PetServiceInterface
    {
        private readonly PetContext _context;

        public PetServiceDb(PetContext context)
        {
            _context = context;
        }

        void PetServiceInterface.AddNewPet(Pet pet)
        {
            _context.pets.Add(pet);
            _context.SaveChanges();
        }

        void PetServiceInterface.DeletePet(int id)
        {
            var pet = _context.pets.FirstOrDefault(p => p.Id == id);
            if (pet is not null)
            {
                _context.pets.Remove(pet);
                _context.SaveChanges();
            }
        }

        List<Pet> PetServiceInterface.GetAllPets()
        {
            return _context.pets.ToList();
        }

        Pet? PetServiceInterface.GetPet(int id)
        {
            return _context.pets.SingleOrDefault(p => p.Id == id);
        }

        void PetServiceInterface.UpdatePet(Pet pet)
        {
            // update the pet
            var updatePet = _context.pets.SingleOrDefault(p => p.Id == pet.Id);
            if (updatePet is not null)
            {
                updatePet.Name = pet.Name;
                updatePet.Type = pet.Type;
                _context.SaveChanges();
            }
 
        }
    }
}
