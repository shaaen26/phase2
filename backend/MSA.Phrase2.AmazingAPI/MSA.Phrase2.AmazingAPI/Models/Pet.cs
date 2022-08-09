using System.ComponentModel.DataAnnotations;


namespace MSA.Phrase2.AmazingAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
