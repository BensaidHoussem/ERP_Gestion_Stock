
using Core.Models;

public sealed class GetAllListFourArticleHandler : IQueryHandler<GetAllListFourArticleQuery,List<FouarticleDto>>
{

    public readonly IServiceDto<Fouarticle, FouarticleDto> _service;
    public GetAllListFourArticleHandler(IServiceDto<Fouarticle,FouarticleDto> service)
    {
        _service = service;
    }
    public async Task<List<FouarticleDto>> Handle(GetAllListFourArticleQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetAllDto()).Result;
    }
}