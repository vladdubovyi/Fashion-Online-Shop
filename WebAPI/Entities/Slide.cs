using Domain;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Slide : DbEntity
	{
		[MaxLength(256)]
		public string Header { get; set; }
		[MaxLength(256)]
		public string Text { get; set; }
		[MaxLength(16)]
		public string BackgroundColor { get; set; }
		[MaxLength(256)]
		public string ImageSrc { get; set; }
		[MaxLength(256)]
		public string ButtonText { get; set; }
		[MaxLength(256)]
		public string ButtonLink { get; set; }
	}
}
