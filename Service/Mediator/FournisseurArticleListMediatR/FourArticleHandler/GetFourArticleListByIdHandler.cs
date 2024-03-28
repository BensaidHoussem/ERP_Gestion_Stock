
using Core.Models;

public sealed class GetFourArticleListByIdHandler : IQueryHandler<GetFourArticleListById,FouarticleDto>
{
    private readonly IServiceDto<Fouarticle, FouarticleDto> _service;
    public GetFourArticleListByIdHandler(IServiceDto<Fouarticle, FouarticleDto> service)
    {
        _service = service;
    }
    
    public async Task<FouarticleDto> Handle(GetFourArticleListById request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetDtoId(request.id)).Result;
    }
}