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
    public class TagController : Controller
    {
        private ITagRepository _repository;
        private IMapper _mapper;

        public TagController(ITagRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            return Ok(await _repository.GetAllItemsAsync());
        }

        [HttpGet("{id}", Name = "GetTagById")]
        public async Task<IActionResult> GetTagById(Guid Id)
        {
            var tag = await _repository.GetItemAsync(Id);
            if (tag == null) return NotFound();
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTag([FromBody] TagCreateDTO categoryCreateDTO)
        {
            var tag = _mapper.Map<Tag>(categoryCreateDTO);

            if (await _repository.AddItemAsync(tag))
            {
                await _repository.SaveChangesAsync();

                var tagGetDTO = _mapper.Map<TagGetDTO>(tag);

                return CreatedAtRoute(nameof(GetTagById),
                                      new { Id = tag.Id },
                                      tagGetDTO);
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTag([FromBody] TagUpdateDTO tagUpdateDTO)
        {
            var tag = _mapper.Map<Tag>(tagUpdateDTO);

            if (await _repository.ChangeItemAsync(tag))
            {
                await _repository.SaveChangesAsync();

                var tagGetDTO = _mapper.Map<TagUpdateDTO>(tag);

                return Ok(tagGetDTO);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagById(Guid Id)
        {
            if (await _repository.DeleteItemAsync(Id)) return Ok($"Deleted tag with Id {Id}");
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllTags()
        {
            if (await _repository.DeleteAllItemsAsync()) return Ok($"Deleted all tags");
            return NotFound();
        }
    }
}
