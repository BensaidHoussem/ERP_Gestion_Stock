using Core.Models;
using MediatR;

public sealed class GetArticleByIdQueryHandler : IQueryHandler<GetArticleByIdQuery, ArticleDto>
{
    public readonly IServiceDto<Article,ArticleDto> _service;

    public GetArticleByIdQueryHandler(IServiceDto<Article,ArticleDto> service)
    {
        _service = service;
    }
    async Task<ArticleDto> IRequestHandler<GetArticleByIdQuery, ArticleDto>.Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetDtoId(request.id)).Result;
    }
}