using Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers
{
	[ApiController]
	[AllowAnonymous]
	[Route("api/[controller]")]
	[EnableCors("AllowOrigin")]
	public class SliderController : Controller
	{
		private readonly ISliderRepository _repository;
		public SliderController(ISliderRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllSlides()
		{
			return Ok(new { Slides = await _repository.GetAllItemsAsync() });
		}
	}
}
