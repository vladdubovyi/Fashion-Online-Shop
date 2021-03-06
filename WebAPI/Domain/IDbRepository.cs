using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDbRepository<T> where T : class, IDbEntity
    {
        DbContext Context { get; }
        IQueryable<T> AllItems { get; }
        Task<List<T>> GetAllItemsAsync ();
        Task<bool> AddItemAsync(T item);
        Task<int> AddItemsAsync(IEnumerable<T> items);
        Task<T> GetItemAsync(Guid id);
        Task<bool> ChangeItemAsync(T item);
        Task<bool> DeleteItemAsync(Guid id);
        Task<bool> DeleteAllItemsAsync();
        Task<int> SaveChangesAsync();
    }
}
