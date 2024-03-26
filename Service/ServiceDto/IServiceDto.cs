public interface IServiceDto<TEntity,Dto>{

    Task<List<Dto>> GetAllDto();
    Task<Dto> GetDtoId(string id);
    Task<bool> AddDto(Dto dto);
    Task<bool> UpdateDto(Dto dto);
    Task<bool> DeleteDto(string id);


}