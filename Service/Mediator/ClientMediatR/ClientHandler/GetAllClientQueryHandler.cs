
using Core.Models;

public sealed class GetAllClientQueryHandler : IQueryHandler<GetAllClientQuery,List<ClientDto>>
{    protected readonly IServiceDto<Client,ClientDto> _client;
    public GetAllClientQueryHandler(IServiceDto<Client,ClientDto> client)
    {
        _client = client;
    }

    public async Task<List<ClientDto>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        //return await Task.FromResult(_client.GetAllDto()).Result;
        return await _client.GetAllDto();
    }
}