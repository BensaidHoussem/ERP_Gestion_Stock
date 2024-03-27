
using Core.Models;

public class GetAllCommandQueryHandler : IQueryHandler<GetAllCommandQuery, List<CommandeDto>>
{

    public readonly IServiceDto<Commande,CommandeDto>_service;

    public GetAllCommandQueryHandler(IServiceDto<Commande,CommandeDto> service)
    {
        _service = service;
    }

    public async Task<List<CommandeDto>> Handle(GetAllCommandQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetAllDto()).Result;
    }
}