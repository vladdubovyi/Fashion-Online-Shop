using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Generic
{
    public class DbRepository<T> : IDbRepository<T> where T : class, IDbEntity
    {
        public DbContext Context { get; }
        public DbRepository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<T> AllItems => Context.Set<T>();

        DbContext IDbRepository<T>.Context => throw new NotImplementedException();

        public async Task<bool> AddItemAsync(T value)
        {
            await Context.Set<T>().AddAsync(value);
            return await SaveChangesAsync() > 0;
        }

        public async Task<int> AddItemsAsync(IEnumerable<T> items)
        {
            await Context.Set<T>().AddRangeAsync(items);
            return await SaveChangesAsync();
        }

        public async Task<bool> ChangeItemAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            T candidate = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (candidate != null)
            {
                Context.Set<T>().Remove(candidate);
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<T> GetItemAsync(Guid id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAllItemsAsync()
        {
            return await AllItems.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
