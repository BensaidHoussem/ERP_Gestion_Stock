
using Core.Models;

public sealed class GetFournisseurByIdHandler : IQueryHandler<GetFournisseurById, FournisseurDto>
{
    protected readonly IServiceDto<Fournisseur,FournisseurDto> _service;

    public GetFournisseurByIdHandler(IServiceDto<Fournisseur,FournisseurDto> service)
    {
        _service = service;
    }



    public async Task<FournisseurDto> Handle(GetFournisseurById request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetDtoId(request.id)).Result;
    }
}