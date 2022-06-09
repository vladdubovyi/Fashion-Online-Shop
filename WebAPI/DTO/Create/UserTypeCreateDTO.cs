using System.ComponentModel.DataAnnotations;

namespace DTOs.Create
{
    public class UserTypeCreateDTO
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
