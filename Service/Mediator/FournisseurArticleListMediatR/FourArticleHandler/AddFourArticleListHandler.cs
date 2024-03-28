
using Core.Models;

public sealed class AddFourArticleListHandler : ICommandHandler<AddFourArticleList, bool>
{
    public readonly IServiceDto<Fouarticle, FouarticleDto> _service;
    public AddFourArticleListHandler(IServiceDto<Fouarticle, FouarticleDto> service)
    {
        _service = service;
    }   
    public async Task<bool> Handle(AddFourArticleList request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.AddDto(request.FouarticleDto)).Result;
    }
}