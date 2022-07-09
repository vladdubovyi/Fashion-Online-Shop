using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Security
{
	public static class Password
	{
		public static string Season(string password, string usersalt, string sitesalt)
		{
			if (string.IsNullOrEmpty(password) ||
				string.IsNullOrEmpty(usersalt) ||
				string.IsNullOrEmpty(sitesalt))
				return null;

			string hash = null;

			// hash password and usersalt
			password = Hashing.SHA512(password);
			usersalt = Hashing.SHA512(usersalt);

			// Re-hash password and salt together
			hash = Hashing.SHA512($"{sitesalt}{password}{usersalt}");

			return hash;
		}
	}
}
