using Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : DbEntity
    {
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(16)]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserType Type { get; set; }
    }
}
