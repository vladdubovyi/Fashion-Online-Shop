using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
	public interface IAuthRepository
	{
		Task<User> TryAuthenticate(string username, string password);
		Task<User> Register(User user);
		string GenerateToken(User user);
	}
}
