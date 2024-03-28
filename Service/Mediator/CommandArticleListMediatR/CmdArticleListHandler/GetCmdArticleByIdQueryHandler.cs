
using Core.Models;

public sealed class GetCmdArticleByIdQueryHandler :
   IQueryHandler<GetCmdArticleByIdQuery, ListarticleDto>
{
    protected readonly IServiceDto<Listarticle,ListarticleDto> _service;

    public GetCmdArticleByIdQueryHandler(IServiceDto<Listarticle,ListarticleDto> service)
    {
        _service = service;
    }

    public async Task<ListarticleDto> Handle(GetCmdArticleByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetDtoId(request.id)).Result;
    }
}