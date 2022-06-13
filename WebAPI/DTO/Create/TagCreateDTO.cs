using System.ComponentModel.DataAnnotations;

namespace DTOs.Create
{
    public class TagCreateDTO
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
