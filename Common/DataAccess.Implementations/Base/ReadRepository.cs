using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class ReadRepository<T, TKey> : IReadRepository<T, TKey>
        where T : class, IDbEntity<TKey>
    {
        protected readonly DbContext _context;
        protected DbSet<T> _collection;

        protected ReadRepository(DbContext context)
        {
            _context = context;
            _collection = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _collection;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _collection.ToListAsync(cancellationToken);
        }
    }

}
