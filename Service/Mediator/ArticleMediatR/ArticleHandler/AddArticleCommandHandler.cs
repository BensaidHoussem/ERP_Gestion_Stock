
using Core.Models;

public class AddArticleCommandHandler : ICommandHandler<AddArticleCommand, bool>
{
    public readonly IServiceDto<Article,ArticleDto> _service;

    public AddArticleCommandHandler(IServiceDto<Article,ArticleDto> service)
    {
        _service = service;
    }


    public async Task<bool> Handle(AddArticleCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_service.AddDto(request.ArticleDto)).Result;
    }
}