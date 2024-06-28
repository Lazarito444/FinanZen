using FinanZen.Data.Contexts;
using FinanZen.Data.Entities;
using FinanZen.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanZen.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationContext _dbContext;

    public UserRepository(ApplicationContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllWithIncludeAsync(List<string> properties)
    {
        ArgumentNullException.ThrowIfNull(properties);
        
        IQueryable<User> query = _dbContext.Set<User>().AsQueryable();
        
        foreach (string property in properties)
        {
            query = query.Include(property);
        }

        return await query.ToListAsync();
    }
}