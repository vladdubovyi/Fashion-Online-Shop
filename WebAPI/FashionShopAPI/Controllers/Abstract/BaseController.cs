using AutoMapper;
using Domain;
using FashionShopAPI.Controllers.Abstract.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace FashionShopAPI.Controllers.Abstract
{
	[ApiController]
	public class BaseController<T> : Controller where T : DbEntity
	{
		protected readonly IDbRepository<T> _repository;
		protected readonly IMapper _mapper;
		protected readonly IConfiguration _configuration;

		public BaseController(IDbRepository<T> repository, IConfiguration _configuration, IMapper mapper)
		{
			_repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
			_mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
			_configuration = _configuration ?? throw new System.ArgumentNullException(nameof(_configuration));
		}

		//TODO: Think about this approach
		[NonAction]
		[Obsolete]
		public IActionResult Ok(string message)
		{
			return new BaseResponse(message);
		}
	}
}
