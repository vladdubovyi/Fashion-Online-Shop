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
	public class CategoryController : BaseController<Category>
	{
		public CategoryController(ICategoryRepository repository, IConfiguration configuration, IMapper mapper) : base(repository, configuration, mapper)
		{ }

		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			return Ok(await _repository.GetAllItemsAsync());
		}

		[HttpGet("{id}", Name = "GetCategoryById")]
		public async Task<IActionResult> GetCategoryById(Guid Id)
		{
			var categoty = await _repository.GetItemAsync(Id);
			if (categoty == null) return NotFound();
			return Ok(categoty);
		}

		[HttpPost]
		public async Task<IActionResult> InsertCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
		{
			var category = _mapper.Map<Category>(categoryCreateDTO);

			if (await _repository.AddItemAsync(category))
			{
				await _repository.SaveChangesAsync();

				var categoryGetDTO = _mapper.Map<CategoryGetDTO>(category);

				return CreatedAtRoute(nameof(GetCategoryById),
									  new { Id = category.Id },
									  categoryGetDTO);
			}
			return BadRequest();
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDTO categoryUpdateDTO)
		{
			var category = _mapper.Map<Category>(categoryUpdateDTO);

			if (await _repository.ChangeItemAsync(category))
			{
				await _repository.SaveChangesAsync();

				var categoryGetDTO = _mapper.Map<CategoryGetDTO>(category);

				return Ok(categoryGetDTO);
			}

			return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategoryById(Guid Id)
		{
			if (await _repository.DeleteItemAsync(Id)) return Ok($"Deleted category with Id {Id}");
			return NotFound();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAllCategories()
		{
			if (await _repository.DeleteAllItemsAsync()) return Ok($"Deleted all categories");
			return NotFound();
		}
	}
}
