
using Core.Models;

public sealed class DeleteFourArticleListHandler : ICommandHandler<DeleteFourArticleList, bool>
{
    public readonly IServiceDto<Fouarticle, FouarticleDto> _service;
    public DeleteFourArticleListHandler(IServiceDto<Fouarticle, FouarticleDto> service)
    {
        _service = service;
    }      
    public async Task<bool> Handle(DeleteFourArticleList request, CancellationToken cancellationToken)
    {
       return await Task.FromResult(_service.DeleteDto(request.id)).Result;
    }
}