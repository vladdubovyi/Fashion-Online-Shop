using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Purchase : DbEntity
    {
        [MaxLength(256)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string Number { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
        public DateTime DateOfSelling { get; set; }
        public User Buyer { get; set; }
        public List<PurchaseProduct> Products { get; set; }
    }
}
