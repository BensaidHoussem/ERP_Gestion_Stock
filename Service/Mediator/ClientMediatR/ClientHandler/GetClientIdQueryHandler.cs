
using System.Formats.Asn1;
using Core.Models;

public sealed class GetClientIdQueryHandler : IQueryHandler<GetClientIdQuery, ClientDto>
{
    protected readonly IServiceDto<Client,ClientDto> _client;
    public GetClientIdQueryHandler(IServiceDto<Client,ClientDto> client)
    {
        _client = client;
    }


    public async Task<ClientDto> Handle(GetClientIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_client.GetDtoId(request.id)).Result;
    }
}