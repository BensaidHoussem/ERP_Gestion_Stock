
using Core.Models;
using Microsoft.EntityFrameworkCore;

public class RepoG<TEntity> : IRepoG<TEntity> where TEntity : class
{
    protected readonly IDbContextErp _dbContextErp;
    protected ErpDbContext _dbcontext=>_dbContextErp?.DbContext;
    protected DbSet<TEntity> _dbset;

    public RepoG(IDbContextErp dbContextErp)
    {
        _dbContextErp = dbContextErp;
        _dbset = _dbcontext.Set<TEntity>();
    }


    public async Task<bool> AddAsync(TEntity entity)
    {
        await _dbset.AddAsync(entity);
        await Save();
        return Task.FromResult(true).Result;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        TEntity entity =await GetByIdAsync(id);
        if(entity != null){
            _dbset.Remove(entity);
            await Save();
            return Task.FromResult(true).Result;
        }
        return Task.FromResult(false).Result;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbset.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        return Task.FromResult<TEntity>(await _dbset.FindAsync(id)).Result;

        //return await _dbset.FindAsync(id);
    }

    public async Task Save()
    {
         await _dbcontext.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        _dbset.Update(entity);
         _dbcontext.ConfigureAwait(false); 
        await Save();
        return Task.FromResult(true).Result;
       
    }
}