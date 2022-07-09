using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstract;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers
{
	[ApiController]
	[AllowAnonymous]
	[Route("api/[controller]")]
	[EnableCors("AllowOrigin")]
	public class CollectionController : Controller
	{
		private readonly ICollectionRepository _repository;
		public CollectionController(ICollectionRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCollections()
		{
			return Ok(new { Collections = await _repository.GetAllItemsAsync() });
		}
	}
}
