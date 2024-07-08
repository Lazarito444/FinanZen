using FinanZen.Data.Contexts;
using FinanZen.Data.Entities;
using FinanZen.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanZen.Data.Repositories;

public class UserEarningRepository : GenericRepository<UserEarning>, IUserEarningRepository
{
    private readonly ApplicationContext _dbContext;

    public UserEarningRepository(ApplicationContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<UserEarning>> GetAllWithIncludeAsync(List<string> properties)
    {
        ArgumentNullException.ThrowIfNull(properties);
        
        IQueryable<UserEarning> query = _dbContext.Set<UserEarning>().AsQueryable();
    
        foreach (string property in properties)
        {
            query = query.Include(property);
        }

        return await query.ToListAsync();
    }
}