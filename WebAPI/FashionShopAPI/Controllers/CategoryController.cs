using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _repository.GetAllItemsAsync());
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            return Ok(await _repository.GetItemAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] Category category)
        {
            /*
            if(await _repository.AddItemAsync(category))
            {
                await _repository.SaveChangesAsync();

                return CreatedAtRoute(nameof(GetCategoryById),
                                      new { Id = category.Id },
                                      category);
            }
            return BadRequest();
            */
            var test = new Category { Name = "test", Id = Guid.NewGuid() };
            await _repository.AddItemAsync(test);
            return CreatedAtRoute(nameof(GetCategoryById),
                                      new { Id = test.Id },
                                      test);
        }
    }
}
