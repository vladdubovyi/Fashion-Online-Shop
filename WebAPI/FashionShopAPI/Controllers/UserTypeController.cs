﻿using AutoMapper;
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
    public class UserTypeController : Controller
    {
        private IUserTypeRepository _repository;
        private IMapper _mapper;

        public UserTypeController(IUserTypeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserTypes()
        {
            return Ok(await _repository.GetAllItemsAsync());
        }

        [HttpGet("{id}", Name = "GetUserTypeById")]
        public async Task<IActionResult> GetUserTypeById(Guid Id)
        {
            var userType = await _repository.GetItemAsync(Id);
            if (userType == null) return NotFound();
            return Ok(userType);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserType([FromBody] UserTypeCreateDTO userTypeCreateDTO)
        {
            var userType = _mapper.Map<UserType>(userTypeCreateDTO);

            if (await _repository.AddItemAsync(userType))
            {
                await _repository.SaveChangesAsync();

                var userTypeGetDTO = _mapper.Map<UserTypeGetDTO>(userType);

                return CreatedAtRoute(nameof(GetUserTypeById),
                                      new { Id = userType.Id },
                                      userTypeGetDTO);
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUserType([FromBody] UserTypeUpdateDTO userTypeUpdateDTO)
        {
            var userType = _mapper.Map<UserType>(userTypeUpdateDTO);

            if (await _repository.ChangeItemAsync(userType))
            {
                await _repository.SaveChangesAsync();

                var userTypeGetDTO = _mapper.Map<UserTypeUpdateDTO>(userType);

                return Ok(userTypeGetDTO);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTypeById(Guid Id)
        {
            if (await _repository.DeleteItemAsync(Id)) return Ok($"Deleted user type with Id {Id}");
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllUserTypes()
        {
            if (await _repository.DeleteAllItemsAsync()) return Ok($"Deleted all user types");
            return NotFound();
        }
    }
}