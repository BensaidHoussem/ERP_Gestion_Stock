using Core.Models;
using MediatR;

public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand, bool>
{
    public readonly IServiceDto<Article,ArticleDto> _service;

    public DeleteArticleCommandHandler(IServiceDto<Article,ArticleDto> service)
    {
        _service = service;
    }
    async Task<bool> IRequestHandler<DeleteArticleCommand, bool>.Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.DeleteDto(request.id)).Result;
    }
}