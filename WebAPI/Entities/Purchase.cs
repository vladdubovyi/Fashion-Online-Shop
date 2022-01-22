using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Purchase : DbEntity
    {
        public DateTime DateOfSelling { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
        public User Buyer { get; set; }
        public List<PurchaseProduct> Products { get; set; }
    }
}
