
using Core.Models;

public class UpdateCommandCmdHandler : ICommandHandler<UpdateCommandCmd, bool>
{

    public readonly IServiceDto<Commande,CommandeDto>_service;

    public UpdateCommandCmdHandler(IServiceDto<Commande,CommandeDto> service)
    {
        _service = service;
    }
    
    public async Task<bool> Handle(UpdateCommandCmd request, CancellationToken cancellationToken)
    {
        
        return await Task.FromResult(_service.UpdateDto(request.cmd)).Result;
    }
}