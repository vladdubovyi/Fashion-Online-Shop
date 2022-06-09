using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOs.Create
{
    public class ProductCreateDTO
    {
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public List<Guid> TagsId { get; set; }
    }
}
