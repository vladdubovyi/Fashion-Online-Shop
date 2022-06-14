using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Security
{
	public static class Hashing
	{
		public static string SHA512(string input)
		{
			return SHA512(input, Encoding.Unicode);
		}
		public static string SHA512(string input, Encoding encoding)
		{
			using var sha512 = System.Security.Cryptography.SHA512.Create();

			byte[] input_bytes = encoding.GetBytes(input ?? string.Empty);
			byte[] hash_bytes = sha512.ComputeHash(input_bytes);

			return HexStringFromBytes(hash_bytes);
		}
		private static string HexStringFromBytes(byte[] bytes)
		{
			var sb = new StringBuilder();

			foreach (byte b in bytes)
			{
				sb.AppendFormat("{0:x2}", b);
			}

			return sb.ToString();
		}
	}
}
