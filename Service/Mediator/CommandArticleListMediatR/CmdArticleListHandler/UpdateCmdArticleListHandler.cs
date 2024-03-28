
using Core.Models;

public sealed class UpdateCmdArticleListHandler : ICommandHandler<UpdateCmdArticleList, bool>
{
   protected readonly IServiceDto<Listarticle,ListarticleDto> _service;

    public UpdateCmdArticleListHandler(IServiceDto<Listarticle,ListarticleDto> service)
    {
        _service = service;
    }
    public async Task<bool> Handle(UpdateCmdArticleList request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.UpdateDto(request.ListarticleDto)).Result;
    }
}