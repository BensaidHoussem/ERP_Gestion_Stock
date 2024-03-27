
using Core.Models;

public sealed class DeleteCommandCmdHandler : ICommandHandler<DeleteCommandCmd, bool>
{
    public readonly IServiceDto<Commande,CommandeDto>_service;

    public DeleteCommandCmdHandler(IServiceDto<Commande,CommandeDto> service)
    {
        _service = service;
    }


    public async Task<bool> Handle(DeleteCommandCmd request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.DeleteDto(request.id)).Result;
    }
}