using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
    public class ProductTagRepository : DbRepository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(DbContext context) : base(context)
        {

        }
    }
}
