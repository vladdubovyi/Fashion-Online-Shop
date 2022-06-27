using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
	public class SliderRepository : DbRepository<Slide>, ISliderRepository
	{
		public SliderRepository(DbContext context) : base(context)
		{

		}
	}
}
