
using Core.Models;

public sealed class AddFournisseurCommandHandler : ICommandHandler<AddFournisseurCommand, bool>
{
    protected readonly IServiceDto<Fournisseur,FournisseurDto> _service;

    public AddFournisseurCommandHandler(IServiceDto<Fournisseur,FournisseurDto> service)
    {
        _service = service;
    }

    public async Task<bool> Handle(AddFournisseurCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.AddDto(request.FournisseurDto)).Result;
    }
}