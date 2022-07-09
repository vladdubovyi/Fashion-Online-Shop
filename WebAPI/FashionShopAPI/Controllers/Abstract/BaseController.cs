using AutoMapper;
using Domain;
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
	}
}
