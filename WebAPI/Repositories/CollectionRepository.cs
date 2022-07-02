using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
	public class CollectionRepository : DbRepository<Collection>, ICollectionRepository
	{
		public CollectionRepository(DbContext context) : base(context)
		{

		}
	}
}
