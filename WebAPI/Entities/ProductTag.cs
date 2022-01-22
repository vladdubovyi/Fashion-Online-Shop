using Domain;

namespace Entities
{
    public class ProductTag : DbEntity
    {
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
