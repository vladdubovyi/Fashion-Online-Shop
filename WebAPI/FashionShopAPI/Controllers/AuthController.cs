using AutoMapper;
using DTOs.Post;
using Entities;
using FashionShopAPI.Controllers.Abstract;
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
		private readonly IMapper _mapper;
		public AuthController(IAuthRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
		{
			var user = await _repository.TryAuthenticate(userLogin.Email, userLogin.Password);

			if (user == null)
				return NotFound();

			var token = _repository.GenerateToken(user);

			return Ok(new
			{
				Status = 200,
				Token = token
			});
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
		{
			var userModel = _mapper.Map<User>(userRegister);

			var user = await _repository.Register(userModel);

			if (user == null)
				return BadRequest();

			var token = _repository.GenerateToken(user);

			return StatusCode(201, new
			{
				Status = 201,
				Token = token
			});
		}
	}
}
