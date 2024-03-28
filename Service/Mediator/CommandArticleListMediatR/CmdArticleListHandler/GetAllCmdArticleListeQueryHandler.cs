
using Core.Models;

public sealed class GetAllCmdArticleListeQueryHandler :
    IQueryHandler<GetAllCmdArticleListeQuery, List<ListarticleDto>>
{
    protected readonly IServiceDto<Listarticle,ListarticleDto> _service;

    public GetAllCmdArticleListeQueryHandler(IServiceDto<Listarticle,ListarticleDto> service)
    {
        _service = service;
    }    
    public async Task<List<ListarticleDto>> Handle(GetAllCmdArticleListeQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetAllDto()).Result;
    }
}