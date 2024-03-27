using Core.Models;
using MediatR;

public sealed class GetAllArticleQueryHandler : IQueryHandler<GetAllArticleQuery, List<ArticleDto>>
{

    public readonly IServiceDto<Article,ArticleDto> _service;

    public GetAllArticleQueryHandler(IServiceDto<Article,ArticleDto> service)
    {
        _service = service;
    }

    async Task<List<ArticleDto>> IRequestHandler<GetAllArticleQuery, List<ArticleDto>>.Handle(GetAllArticleQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.GetAllDto()).Result;
    }
}