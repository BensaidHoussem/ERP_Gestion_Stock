
using Core.Models;

public sealed class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand, bool>
{
    protected readonly IServiceDto<Client,ClientDto> _client;
    public DeleteClientCommandHandler(IServiceDto<Client,ClientDto> client)
    {
        _client = client;
    }    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_client.DeleteDto(request.id)).Result;
    }
}