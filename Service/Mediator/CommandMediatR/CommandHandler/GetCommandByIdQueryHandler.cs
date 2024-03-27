
using Core.Models;

public class GetCommandByIdQueryHandler : IQueryHandler<GetCommandByIdQuery, CommandeDto>
{
    public readonly IServiceDto<Commande,CommandeDto>_service;

    public GetCommandByIdQueryHandler(IServiceDto<Commande,CommandeDto> service)
    {
        _service = service;
    }


    public async Task<CommandeDto> Handle(GetCommandByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetDtoId(request.id)).Result;
    }
}