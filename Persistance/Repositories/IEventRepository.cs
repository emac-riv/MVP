using Persistance.Entities;
using Persistance.Models;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    public interface IEventRepository
    {
        Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync(EventEntity entity);
        Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression);
    }
}