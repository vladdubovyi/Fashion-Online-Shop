using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product : DbEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public List<ProductTag> Tags { get; set; }
    }
}
