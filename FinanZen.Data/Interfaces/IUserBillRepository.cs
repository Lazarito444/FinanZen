using FinanZen.Data.Entities;

namespace FinanZen.Data.Interfaces;

public interface IUserBillRepository : IGenericRepository<UserBill>
{
    public Task<List<UserBill>> GetAllWithIncludeAsync(List<string> properties);

}