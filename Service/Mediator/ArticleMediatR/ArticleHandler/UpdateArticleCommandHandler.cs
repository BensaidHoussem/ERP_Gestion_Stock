using Core.Models;
using MediatR;

public sealed class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, bool>
{

    public readonly IServiceDto<Article,ArticleDto> _service;

    public UpdateArticleCommandHandler(IServiceDto<Article,ArticleDto> service)
    {
        _service = service;
    }


    async Task<bool> IRequestHandler<UpdateArticleCommand, bool>.Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.UpdateDto(request.articleDto)).Result;
    }
}