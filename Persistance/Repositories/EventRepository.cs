using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;
using Persistance.Models;
using System.Linq.Expressions;


namespace Persistance.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
    public override async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync(EventEntity entity)
    {
        try
        {
            var entities = await _table.Include(x => x.Packages).ToListAsync();

            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = true,
                Result = entities,
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public override async Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.Packages).FirstOrDefaultAsync(expression) ?? throw new Exception("Not found");
            return new RepositoryResult<TEntity?>
            {
                Success = true,
                Result = entity,
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult<TEntity?>
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }
}