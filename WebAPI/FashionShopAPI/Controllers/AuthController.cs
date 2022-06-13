using DTOs.Post;
using FashionShopAPI.Controllers.Abstract;
using FashionShopAPI.Controllers.Abstract.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstract;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers
{
	[ApiController]
	[AllowAnonymous]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly IAuthRepository _repository;
		public AuthController(IAuthRepository repository)
		{
			_repository = repository;
		}
		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
		{
			var user = await _repository.TryAuthenticate(userLogin.Email, userLogin.Password);

			if (user == null)
				return NotFound();

			var token = _repository.GenerateToken(user);

			return Ok(token);
		}
	}
}
