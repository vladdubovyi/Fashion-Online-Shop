using Domain;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class UserType : DbEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
    }
}