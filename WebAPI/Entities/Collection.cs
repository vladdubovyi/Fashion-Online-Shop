using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Collection : DbEntity
	{
		[MaxLength(256)]
		public string Name { get; set; }
		[MaxLength(256)]
		public string ImageSrc { get; set; }
	}
}
