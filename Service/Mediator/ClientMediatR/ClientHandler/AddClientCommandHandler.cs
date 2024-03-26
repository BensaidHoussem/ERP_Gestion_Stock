
using Core.Models;

public sealed class AddClientCommandHandler : ICommandHandler<AddClientCommand, bool>
{
    protected readonly IServiceDto<Client,ClientDto> _client;
    public AddClientCommandHandler(IServiceDto<Client,ClientDto> client)
    {
        _client = client;
    }


    public Task<bool> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_client.AddDto(request.clientDto)).Result;
    }
}