using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FashionShopAPI.Controllers.Abstract.Responses
{
	public class BaseResponse : IActionResult
	{
		protected string _message { get; set; }
		public BaseResponse(string message)
		{
			_message = message;
		}

		public async Task ExecuteResultAsync(ActionContext context)
		{
			var objectResult = new ObjectResult(_message)
			{
				StatusCode = 201,
				Value = _message
			};

			await objectResult.ExecuteResultAsync(context);
		}
	}
}
