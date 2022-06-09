using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs.Create
{
    public class UserCreateDTO
    {
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(64)]
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? TypeId { get; set; }
    }
}
