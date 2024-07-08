using FinanZen.Data.Contexts;
using FinanZen.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanZen.Data.Repositories;

public class GenericRepository<Entity> : IGenericRepository<Entity>
    where Entity : class
{
    private readonly ApplicationContext _dbContext;

    public GenericRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Entity> AddAsync(Entity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        await _dbContext.Set<Entity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Entity entity, int id)
    {
        ArgumentNullException.ThrowIfNull(entity);
        if (id <= 0) throw new ArgumentOutOfRangeException();
        
        Entity? entry = await _dbContext.Set<Entity>().FindAsync(id);
        _dbContext.Entry(entry).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Entity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        _dbContext.Set<Entity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Entity> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException();
        
        return await _dbContext.Set<Entity>().FindAsync(id);
    }

    public async Task<List<Entity>> GetAllAsync()
    {
        return await _dbContext.Set<Entity>().ToListAsync();
    }
}