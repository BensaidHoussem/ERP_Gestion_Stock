
using Core.Models;

public class AddCommandCmdHandler : ICommandHandler<AddCommandCmd, bool>
{
    public readonly IServiceDto<Commande,CommandeDto>_service;

    public AddCommandCmdHandler(IServiceDto<Commande,CommandeDto> service)
    {
        _service = service;
    }

    public async Task<bool> Handle(AddCommandCmd request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.AddDto(request.cmd)).Result; 
    }
}