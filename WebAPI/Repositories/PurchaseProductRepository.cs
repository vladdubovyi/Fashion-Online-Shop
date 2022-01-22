using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
    public class PurchaseProductRepository : DbRepository<PurchaseProduct>, IPurchaseProductRepository
    {
        public PurchaseProductRepository(DbContext context) : base(context)
        {

        }
    }
}
