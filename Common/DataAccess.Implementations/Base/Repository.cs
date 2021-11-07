using System.Threading.Tasks;
using DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class Repository<T, Tkey> : ReadRepository<T, Tkey>, IRepository<T, Tkey>
        where T : class, IDbEntity<Tkey>
    {
        public Repository(DbContext context) : base(context) { }

        public void Add(T entity)
        {
            _collection.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _collection.AddAsync(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
