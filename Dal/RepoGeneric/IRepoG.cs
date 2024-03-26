public interface IRepoG<TEntity>{
    Task<List<TEntity>>GetAllAsync();
    Task<TEntity> GetByIdAsync(string id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(string id);
    Task Save();

}