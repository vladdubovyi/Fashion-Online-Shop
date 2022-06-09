using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs.Update
{
    public class UserUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? TypeId { get; set; }
    }
}
