using Domain;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : DbEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
