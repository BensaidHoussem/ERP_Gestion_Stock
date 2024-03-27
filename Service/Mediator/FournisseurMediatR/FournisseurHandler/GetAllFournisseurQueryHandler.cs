
using Core.Models;

public sealed class GetAllFournisseurQueryHandler :
    IQueryHandler<GetAllFournisseurQuery, List<FournisseurDto>>
{
    protected readonly IServiceDto<Fournisseur,FournisseurDto> _service;

    public GetAllFournisseurQueryHandler(IServiceDto<Fournisseur,FournisseurDto> service)
    {
        _service = service;
    }


    public async Task<List<FournisseurDto>> Handle(GetAllFournisseurQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetAllDto()).Result;
    }
}