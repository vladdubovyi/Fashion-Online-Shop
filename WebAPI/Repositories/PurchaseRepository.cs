using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
    public class PurchaseRepository : DbRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(DbContext context) : base(context)
        {

        }
    }
}
