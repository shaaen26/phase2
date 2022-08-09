using Microsoft.EntityFrameworkCore;
using MSA.Phrase2.AmazingAPI.Models;

namespace MSA.Phrase2.AmazingAPI.Data
{
    public class PetContext : DbContext
    {
        public PetContext (DbContextOptions<PetContext> options) 
            : base(options)
        {

        }

        public DbSet<Pet> pets => Set<Pet>();
    }
}
