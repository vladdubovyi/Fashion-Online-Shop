using Domain;

namespace Entities
{
    public class UserType : DbEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}