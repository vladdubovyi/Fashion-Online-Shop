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
		private readonly IConfiguration _configuration;
		private readonly JwtConfig _jwtConfig;
		public AuthRepository(AppDbContext context, IConfiguration configuration, IOptionsMonitor<JwtConfig> optionsMonitor)
		{
			_db = context ?? throw new ArgumentNullException(nameof(context));
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_jwtConfig = optionsMonitor.CurrentValue ?? throw new ArgumentNullException(nameof(optionsMonitor));
		}

		public async Task<User> TryAuthenticate(string email, string password)
		{
			// Getting users only by email
			var user = await _db.Users
				.Where(u => u.Email == email)
				.FirstOrDefaultAsync();

			if (user == null)
				return null;

			// Getting user and site salts
			var userSalt = Utilities.Time.GetUnixTimeStamp(user.CreatedOn).ToString();
			var siteSalt = _configuration.GetValue<string>("WebsiteSalt");

			// Seasoning input password and comparing with PasswordHash from db
			if (user.PasswordHASH == Utilities.Security.Password.Season(password, userSalt, siteSalt))
				return user;

			return null;
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
				Expires = DateTime.UtcNow.AddMinutes(15),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
			var jwtToken = jwtTokenHandler.WriteToken(token);

			return jwtToken;
		}

		public async Task<User> Register(User user)
		{
			// Getting users only by email
			var userTemp = await _db.Users
				.Where(u => u.Email == user.Email)
				.FirstOrDefaultAsync();

			if (userTemp != null)
				return null;

			user.CreatedOn = DateTime.UtcNow;

			// Getting user and site salts
			var userSalt = Utilities.Time.GetUnixTimeStamp(user.CreatedOn).ToString();
			var siteSalt = _configuration.GetValue<string>("WebsiteSalt");

			// Hashing users' password
			user.PasswordHASH = Utilities.Security.Password.Season(user.PasswordHASH, userSalt, siteSalt);

			_db.Users.Add(user);
			await _db.SaveChangesAsync();

			return user;
		}
	}
}
