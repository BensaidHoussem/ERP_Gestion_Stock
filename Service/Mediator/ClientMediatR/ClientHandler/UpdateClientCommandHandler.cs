using Core.Models;
using MediatR;

public sealed class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand,bool>
{

    protected readonly IServiceDto<Client,ClientDto> _client;
    public UpdateClientCommandHandler(IServiceDto<Client,ClientDto> client)
    {
        _client = client;
    }
    public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_client.UpdateDto(request.clientDto)).Result;  
         
    }
}