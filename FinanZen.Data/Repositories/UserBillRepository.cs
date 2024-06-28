using FinanZen.Data.Contexts;
using FinanZen.Data.Entities;
using FinanZen.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanZen.Data.Repositories;

public class UserBillRepository : GenericRepository<UserBill>, IUserBillRepository
{

    private readonly ApplicationContext _dbContext;
    
    public UserBillRepository(ApplicationContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<UserBill>> GetAllWithIncludeAsync(List<string> properties)
    {
        IQueryable<UserBill> query = _dbContext.Set<UserBill>().AsQueryable();
        
        foreach (string property in properties)
        {
            query = query.Include(property);
        }

        return await query.ToListAsync();
    }
}