using Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class PurchaseProduct : DbEntity
    {
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
    }

}
