using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Abstractions
{
    public interface IBaseRepository { }

    public interface IReadRepository<T, TKey> : IBaseRepository
        where T: IDbEntity<TKey>
    {
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
