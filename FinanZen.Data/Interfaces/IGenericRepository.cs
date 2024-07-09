namespace FinanZen.Data.Interfaces;

public interface IGenericRepository<Entity>
{
    public Task<Entity> AddAsync(Entity entity);

    public Task UpdateAsync(Entity entity, int id);

    public Task DeleteAsync(Entity entity);

    Task<Entity> GetByIdAsync(int id);

    Task<List<Entity>> GetAllAsync();
}