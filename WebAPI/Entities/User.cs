using Domain;
using System;

namespace Entities
{
    public class User : DbEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserType Type { get; set; }
    }
}
