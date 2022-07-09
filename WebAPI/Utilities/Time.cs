using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
	public static class Time
	{
		public static readonly DateTime UnixEpochStart = DateTime.Parse("1970-01-01 00:00:00.000");

		public static long GetUnixTimeStamp() { return GetUnixTimeStamp(DateTime.Now); }
		public static long GetUnixTimeStamp(DateTime time)
		{
			return (long)(time - UnixEpochStart).TotalSeconds;
		}
	}
}
