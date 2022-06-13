using Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Tag : DbEntity
	{
		[MaxLength(64)]
		public string Name { get; set; }
		public List<Product> Products { get; set; }
	}
}
