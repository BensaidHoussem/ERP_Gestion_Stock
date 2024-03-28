
using Core.Models;

public sealed class UpdateFourArticleListHandler : ICommandHandler<UpdateFourArticleList, bool>
{
    private readonly IServiceDto<Fouarticle, FouarticleDto> _service;
    public UpdateFourArticleListHandler(IServiceDto<Fouarticle, FouarticleDto> service)
    {
        _service = service;
    }    
    public async  Task<bool> Handle(UpdateFourArticleList request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.UpdateDto(request.FouarticleDtoRecord)).Result;
    }
}