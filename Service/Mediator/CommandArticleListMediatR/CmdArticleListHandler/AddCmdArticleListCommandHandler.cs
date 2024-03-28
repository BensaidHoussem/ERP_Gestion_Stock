
using Core.Models;

public sealed class AddCmdArticleListCommandHandler : ICommandHandler<AddCmdArticleListCommand, bool>
{
#pragma warning disable CS0628 // New protected member declared in sealed type
    protected readonly IServiceDto<Listarticle,ListarticleDto> _service;

    public AddCmdArticleListCommandHandler(IServiceDto<Listarticle,ListarticleDto> service)
    {
        _service = service;
    }
    public async Task<bool> Handle(AddCmdArticleListCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.AddDto(request.ListarticleDtoList)).Result;
    }
}