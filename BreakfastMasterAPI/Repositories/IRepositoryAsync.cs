namespace BreakfastMasterAPI.Repositories
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        void Remove(TEntity entity);
        void RemoveRange(List<TEntity> entities);
        Task SaveChangesAsync();
    }
}