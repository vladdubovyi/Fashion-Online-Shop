using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
    public class UserTypeRepository : DbRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
