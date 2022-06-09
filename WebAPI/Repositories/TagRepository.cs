using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;

namespace Repositories
{
    public class TagRepository : DbRepository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {

        }
    }
}
