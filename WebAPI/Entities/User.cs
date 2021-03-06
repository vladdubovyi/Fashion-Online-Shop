using Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class User : DbEntity
	{
		[MaxLength(64)]
		public string UserName { get; set; }
		[MaxLength(256)]
		public string PasswordHASH { get; set; }
		[MaxLength(64)]
		public string FirstName { get; set; }
		[MaxLength(64)]
		public string LastName { get; set; }
		[MaxLength(16)]
		public string PhoneNumber { get; set; }
		[MaxLength(128)]
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
	}
}
