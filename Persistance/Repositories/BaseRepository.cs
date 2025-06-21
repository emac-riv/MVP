using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public abstract class BaseRepository<TEntity, > where TEntity : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _table;

        protected BaseRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task<RespositoryResult> AddAsync(TEntity entity)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return
            }
        }
    }
}
