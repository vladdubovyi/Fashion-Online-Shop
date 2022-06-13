using System.ComponentModel.DataAnnotations;

namespace DTOs.Create
{
    public class CategoryCreateDTO
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
