
using Core.Models;

public sealed class DeleteCmdArticleListCommandHandler : ICommandHandler<DeleteCmdArticleListCommand, bool>
{
    protected readonly IServiceDto<Listarticle,ListarticleDto> _service;

    public DeleteCmdArticleListCommandHandler(IServiceDto<Listarticle,ListarticleDto> service)
    {
        _service = service;
    }

    public async Task<bool> Handle(DeleteCmdArticleListCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.DeleteDto(request.id)).Result;
    }
}