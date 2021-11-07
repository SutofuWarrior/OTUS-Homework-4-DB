using System.Threading.Tasks;

namespace DataAccess.Abstractions
{
    public interface IRepository<T, TKey> : IReadRepository<T, TKey>
        where T: IDbEntity<TKey>
    {
        void Add(T entity);

        Task AddAsync(T entity);

        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
