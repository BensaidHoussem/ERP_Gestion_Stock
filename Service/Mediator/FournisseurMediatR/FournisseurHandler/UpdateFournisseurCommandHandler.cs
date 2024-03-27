
using Core.Models;

public sealed class UpdateFournisseurCommandHandler : ICommandHandler<UpdateFournisseurCommand, bool>
{
    protected readonly IServiceDto<Fournisseur,FournisseurDto> _service;

    public UpdateFournisseurCommandHandler(IServiceDto<Fournisseur,FournisseurDto> service)
    {
        _service = service;
    }    
    public async Task<bool> Handle(UpdateFournisseurCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.UpdateDto(request.FournisseurDto)).Result;
    }
}