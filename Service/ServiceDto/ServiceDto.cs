using System.Runtime.InteropServices;
using AutoMapper;

public class ServiceDto<TEntity, Dto> : IServiceDto<TEntity, Dto>
    where TEntity : class
    where Dto : class
{

    protected readonly IRepoG<TEntity> _repo;
    protected readonly IMapper _mapper;

    public ServiceDto(IRepoG<TEntity> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }


    public async Task<bool> AddDto(Dto dto)
    {
        var entity=_mapper.Map<TEntity>(dto);
        await _repo.AddAsync(entity);
        await _repo.Save();
        return Task.FromResult(true).Result;
    }

    public async Task<bool> DeleteDto(string id)
    {
        var x=await GetDtoId(id);
        var xx=_mapper.Map<TEntity>(x);
        if(x !=null){
            await _repo.DeleteAsync(id);
            await _repo.Save();
            return Task.FromResult(true).Result;
        }
        return Task.FromResult(false).Result;
    }

    public async Task<List<Dto>> GetAllDto()
    {
        var result=await _repo.GetAllAsync();
        var lst=_mapper.Map<List<Dto>>(result);
        return lst;
    }
    public async Task<Dto> GetDtoId(string id)
    {
        var entity = await _repo.GetByIdAsync(id);
        var result=_mapper.Map<Dto>(entity);
        return Task.FromResult(result).Result;

    }

    public async Task<bool> UpdateDto(Dto dto)
    {
        var entity=_mapper.Map<TEntity>(dto);
        await _repo.UpdateAsync(entity);
        return Task.FromResult(true).Result;

    }
}