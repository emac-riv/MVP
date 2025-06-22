using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Models;


namespace Persistance.Repositories;

    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _table;

        protected BaseRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

    public async Task<RepositoryResult> AddAsync(TEntity entity)
    {
        try
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult
            {
                Success = true,
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public async Task<RepositoryResult> UpdateAsync(TEntity entity)
    {
        try
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult
            {
                Success = true,
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }

    public async Task<RepositoryResult> DeleteAsync(TEntity entity)
    {
        try
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult
            {
                Success = true,
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult
            {
                Success = false,
                Error = ex.Message,
            };
        }
    }
}

