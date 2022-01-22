using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs.Update
{
    public class TagUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
