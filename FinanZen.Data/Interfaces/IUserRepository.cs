using FinanZen.Data.Entities;

namespace FinanZen.Data.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<List<User>> GetAllWithIncludeAsync(List<string> properties);
}