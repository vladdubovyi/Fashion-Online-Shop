using AutoMapper;
using DTOs.Create;
using DTOs.Get;
using DTOs.Update;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstract;
using System;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        private IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _repository.GetAllItemsAsync());
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(Guid Id)
        {
            var product = await _repository.GetItemAsync(Id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            var product = _mapper.Map<Product>(productCreateDTO);

            if (await _repository.AddItemAsync(product))
            {
                await _repository.SaveChangesAsync();

                var productGetDTO = _mapper.Map<UserGetDTO>(product);

                return CreatedAtRoute(nameof(GetProductById),
                                      new { Id = product.Id },
                                      productGetDTO);
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO productUpdateDTO)
        {
            var product = _mapper.Map<Product>(productUpdateDTO);

            if (await _repository.ChangeItemAsync(product))
            {
                await _repository.SaveChangesAsync();

                var productGetDTO = _mapper.Map<CategoryGetDTO>(product);

                return Ok(productGetDTO);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(Guid Id)
        {
            if (await _repository.DeleteItemAsync(Id)) return Ok($"Deleted product with Id {Id}");
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllProducts()
        {
            if (await _repository.DeleteAllItemsAsync()) return Ok($"Deleted all products");
            return NotFound();
        }
    }
}
