
using Core.Models;

public sealed class DeleteFournisseurCommandHandler : ICommandHandler<DeleteFournisseurCommand, bool>
{
    protected readonly IServiceDto<Fournisseur,FournisseurDto> _service;

    public DeleteFournisseurCommandHandler(IServiceDto<Fournisseur,FournisseurDto> service)
    {
        _service = service;
    }    
    public async Task<bool> Handle(DeleteFournisseurCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.DeleteDto(request.id)).Result;
    }
}