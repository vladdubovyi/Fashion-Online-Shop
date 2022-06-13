using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repositories.Abstract;
using Repositories.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly AppDbContext _db;
		private readonly JwtConfig _jwtConfig;
		public AuthRepository(AppDbContext context, IConfiguration configuration, IOptionsMonitor<JwtConfig> optionsMonitor)
		{
			_db = context ?? throw new ArgumentNullException(nameof(context));
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_jwtConfig = optionsMonitor.CurrentValue ?? throw new ArgumentNullException(nameof(optionsMonitor));
		}

		public async Task<User> TryAuthenticate(string email, string password)
		{
			// Getting users only by username
			var user = await _db.Users
				.Where(u => u.Email == email)
				.ToListAsync();

			if (user == null)
				return null;

			// TODO: Add user Salt to protect
			var res = user.Where(u => u.Password == password).FirstOrDefault();

			if (res == null) return null;

			return res;
		}

		public string GenerateToken(User user)
		{
			var jwtTokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(JwtRegisteredClaimNames.Email, user.Email)
				}),
				Expires = DateTime.UtcNow.AddHours(6),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
			var jwtToken = jwtTokenHandler.WriteToken(token);

			return jwtToken;
		}
	}
}
