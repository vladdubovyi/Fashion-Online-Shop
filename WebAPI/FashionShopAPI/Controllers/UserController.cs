using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Update;
using Entities;
using FashionShopAPI.Controllers.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repositories.Abstract;
using System;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers
{
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	public class UserController : BaseController<User>
	{
		public UserController(IUserRepository repository, IConfiguration configuration, IMapper mapper) : base(repository, configuration, mapper)
		{ }

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			return Ok(await _repository.GetAllItemsAsync());
		}

		[HttpGet("{id}", Name = "GetUserById")]
		public async Task<IActionResult> GetUserById(Guid Id)
		{
			var user = await _repository.GetItemAsync(Id);
			if (user == null) return NotFound();
			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> InsertUser([FromBody] UserCreateDTO userCreateDTO)
		{
			var user = _mapper.Map<User>(userCreateDTO);

			if (await _repository.AddItemAsync(user))
			{
				await _repository.SaveChangesAsync();

				var userGetDTO = _mapper.Map<UserGetDTO>(user);

				return CreatedAtRoute(nameof(GetUserById),
									  new { Id = user.Id },
									  userGetDTO);
			}
			return BadRequest();
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO userUpdateDTO)
		{
			var user = _mapper.Map<User>(userUpdateDTO);

			if (await _repository.ChangeItemAsync(user))
			{
				await _repository.SaveChangesAsync();

				var userGetDTO = _mapper.Map<CategoryGetDTO>(user);

				return Ok(userGetDTO);
			}

			return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserById(Guid Id)
		{
			if (await _repository.DeleteItemAsync(Id)) return Ok($"Deleted user with Id {Id}");
			return NotFound();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAllUsers()
		{
			if (await _repository.DeleteAllItemsAsync()) return Ok($"Deleted all users");
			return NotFound();
		}
	}
}
