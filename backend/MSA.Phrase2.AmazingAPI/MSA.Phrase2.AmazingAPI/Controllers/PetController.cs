using Microsoft.AspNetCore.Mvc;
using MSA.Phrase2.AmazingAPI.Models;
using MSA.Phrase2.AmazingAPI.Services;

namespace MSA.Phrase2.AmazingAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {

        public PetController()
        {
        }

        /// <summary>
        /// get all pets currently in the system
        /// </summary>
        /// <returns>list of pets</returns>
        [HttpGet]
        public ActionResult<List<Pet>> GetAll()
        {
            return PetService.GetAllPets();
        }
        
        /// <summary>
        /// get the specificed pet with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>mathcing id pet or not found</returns>
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var Pet = PetService.GetPet(id);

            if(Pet is null) { 
                return NotFound();
            }

            return Pet; 
        }

        /// <summary>
        /// add a new pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPet(Pet pet)
        {
            PetService.AddNewPet(pet);
            return CreatedAtAction(nameof(AddPet), new {id=pet.Id}, pet);
        }

        /// <summary>
        /// update the current pet information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pet"></param>
        /// <returns>NoContent response for successfully updating, NotFound for no such pet id existing</returns>
        [HttpPut("{id}")]
        public IActionResult UpdatePetInfo(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            var currentPet = PetService.GetPet(id);
            if (currentPet is null)
            {
                return NotFound();
            }

            PetService.UpdatePet(pet);
            return NoContent();
        }

        /// <summary>
        /// delete a pet from the system based on the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent response for successfully deleting, NotFound for no such pet existing</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            var currentPet = PetService.GetPet(id);

            if (currentPet is null)
            {
                return NotFound();
            }

            PetService.DeletePet(id);
            return NoContent();
        }
    }   
}
