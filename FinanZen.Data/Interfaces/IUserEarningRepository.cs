using FinanZen.Data.Entities;

namespace FinanZen.Data.Interfaces;

public interface IUserEarningRepository : IGenericRepository<UserEarning>
{
    public Task<List<UserEarning>> GetAllWithIncludeAsync(List<string> properties);
}